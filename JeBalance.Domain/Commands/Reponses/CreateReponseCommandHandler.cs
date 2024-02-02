using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.Domain.Commands.Reponses;

public class CreateReponseCommandHandler : IRequestHandler<CreateReponseCommand, int>
{
    private readonly DenonciationRepository _denonciationRepository;
    private readonly IHorodatageProvider _horodatageProvider;
    private readonly InformateurRepository _informateurRepository;
    private readonly ReponseRepository _reponseRepository;

    public CreateReponseCommandHandler(DenonciationRepository denonciationRepository,
        IHorodatageProvider horodatageProvider, ReponseRepository reponseRepository,
        InformateurRepository informateurRepository)
    {
        _denonciationRepository = denonciationRepository;
        _horodatageProvider = horodatageProvider;
        _reponseRepository = reponseRepository;
        _informateurRepository = informateurRepository;
    }

    public async Task<int> Handle(CreateReponseCommand request, CancellationToken cancellationToken)
    {
        var reponse = request.Reponse;


        if (reponse is { TypeReponse: TypeReponse.Confirmation, Retribution: < 0 })
            throw new ApplicationException("Le montant de retribution ne peut pas etre negatif");

        var now = _horodatageProvider.GetNow();
        reponse.Horodatage = now;

        var denonciationId = request.DenonciationId;
        var denonciation = await _denonciationRepository.GetOne(denonciationId);

        if (reponse.TypeReponse == TypeReponse.Rejet)
        {
            reponse.Retribution = null;

            // Si l'informateur a déjà eu 2 réponses de type `Rejet`, on le marque en tant que calomniateur
            if (await _denonciationRepository.Has2ReponsesDeTypeRejet(denonciation.InformateurId))
            {
                var informateur = await _informateurRepository.GetOne(denonciation.InformateurId);
                informateur.EstCalomniateur = true;
                Console.WriteLine($"Informateur {denonciation.InformateurId} marqué comme calomniateur");
                await _informateurRepository.Update(denonciation.InformateurId, informateur);
            }
        }


        if (denonciation.ReponseId != null)
            throw new ApplicationException("Impossible de répondre à une dénonciation qui a déjà une réponse");

        var reponseId = await _reponseRepository.Create(reponse);

        await _denonciationRepository.SetReponseId(denonciationId, reponseId);
        return reponseId;
    }
}