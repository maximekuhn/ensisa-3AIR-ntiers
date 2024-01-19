using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
{
    private readonly DenonciationRepository _denonciationRepository;

    public CreateDenonciationCommandHandler(DenonciationRepository denonciationRepository)
    {
        _denonciationRepository = denonciationRepository;
    }

    public async Task<int> Handle(CreateDenonciationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Récupérer l'id du suspect avec _suspectRepository
            // var informateur = request.Informateur;
            // var idInformateur = _informateurRepository.insertOrFind(informateur);

            // Récupérer l'id de l'informateur avec _informateurRepository

            // Faire les checks de calamar ou de VIP

            // Créer la dénonciation dans la base
            //
            // var denonciation = request.Denonciation;
            // denonciation.InformateurId = idInformateur;

            Console.WriteLine("toto");

            var denonciationId = await _denonciationRepository.Create(request.Denonciation);
            return denonciationId;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}