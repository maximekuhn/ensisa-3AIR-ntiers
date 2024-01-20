using JeBalance.Domain.Queries;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
{
    private readonly DenonciationRepository _denonciationRepository;
    private readonly IHorodatageProvider _horodatageProvider;
    private readonly InformateurRepository _informateurRepository;
    private readonly SuspectRepository _suspectRepository;

    public CreateDenonciationCommandHandler(DenonciationRepository denonciationRepository,
        InformateurRepository informateurRepository, SuspectRepository suspectRepository,
        IHorodatageProvider horodatageProvider)
    {
        _denonciationRepository = denonciationRepository;
        _informateurRepository = informateurRepository;
        _suspectRepository = suspectRepository;
        _horodatageProvider = horodatageProvider;
    }

    public async Task<int> Handle(CreateDenonciationCommand request, CancellationToken cancellationToken)
    {
        var denonciation = request.Denonciation;

        var now = _horodatageProvider.GetNow();
        denonciation.Horodatage = now;

        var findSuspectSpecification =
            new FindPersonneSpecification(request.Suspect.Nom, request.Suspect.Prenom, request.Suspect.Adresse);
        var suspect = await _suspectRepository.FindOne(findSuspectSpecification);
        int suspectId;
        if (suspect == null)
            suspectId = await _suspectRepository.Create(request.Suspect);
        else
            suspectId = suspect.Id;
        denonciation.SuspectId = suspectId;

        var findInformateurSuspect = new FindPersonneSpecification(request.Informateur.Nom, request.Informateur.Prenom,
            request.Informateur.Adresse);
        var informateur = await _informateurRepository.FindOne(findInformateurSuspect);
        int informateurId;
        if (informateur == null)
            informateurId = await _informateurRepository.Create(request.Informateur);
        else
            informateurId = informateur.Id;
        denonciation.InformateurId = informateurId;

        var denonciationId = await _denonciationRepository.Create(denonciation);
        return denonciationId;
    }
}