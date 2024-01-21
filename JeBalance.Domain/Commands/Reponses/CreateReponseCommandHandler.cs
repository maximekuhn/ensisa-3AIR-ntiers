using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.Domain.Commands.Reponses;

public class CreateReponseCommandHandler : IRequestHandler<CreateReponseCommand, int>
{
    private readonly DenonciationRepository _denonciationRepository;
    private readonly IHorodatageProvider _horodatageProvider;
    private readonly ReponseRepository _reponseRepository;

    public CreateReponseCommandHandler(ReponseRepository reponseRepository,
        DenonciationRepository denonciationRepository, IHorodatageProvider horodatageProvider)
    {
        _reponseRepository = reponseRepository;
        _denonciationRepository = denonciationRepository;
        _horodatageProvider = horodatageProvider;
    }

    public async Task<int> Handle(CreateReponseCommand request, CancellationToken cancellationToken)
    {
        var reponse = request.Reponse;


        if (reponse is { TypeReponse: TypeReponse.Confirmation, Retribution: < 0 })
            throw new ApplicationException("Le montant de retribution ne peut pas etre negatif");

        if (reponse.TypeReponse == TypeReponse.Rejet) reponse.Retribution = null;

        var now = _horodatageProvider.GetNow();
        reponse.Horodatage = now;

        var denonciationId = request.DenonciationId;
        var denonciation = await _denonciationRepository.GetOne(denonciationId);

        if (denonciation.ReponseId != null)
            throw new ApplicationException("Impossible de répondre à une dénonciation qui a déjà une réponse");

        var reponseId = await _reponseRepository.Create(reponse);

        denonciation.ReponseId = reponseId;

        await _denonciationRepository.Update(denonciationId, denonciation);
        return reponseId;
    }
}