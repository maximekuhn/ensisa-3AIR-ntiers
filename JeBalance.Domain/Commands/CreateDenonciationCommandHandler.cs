using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, Guid>
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

    public async Task<Guid> Handle(CreateDenonciationCommand request, CancellationToken cancellationToken)
    {
        var denonciation = request.Denonciation;

        var now = _horodatageProvider.GetNow();
        denonciation.Horodatage = now;

        var findSuspectSpecification =
            new FindPersonneSpecification<Suspect>(request.Suspect.Nom, request.Suspect.Prenom,
                request.Suspect.Adresse);
        var suspect = await _suspectRepository.FindOne(findSuspectSpecification);
        int suspectId;
        if (suspect == null)
            suspectId = await _suspectRepository.Create(request.Suspect);
        else
            suspectId = suspect.Id;
        denonciation.SuspectId = suspectId;

        var findInformateurSpecification = new FindPersonneSpecification<Informateur>(request.Informateur.Nom,
            request.Informateur.Prenom, request.Suspect.Adresse);
        var informateur = await _informateurRepository.FindOne(findInformateurSpecification);
        int informateurId;
        if (informateur == null)
            informateurId = await _informateurRepository.Create(request.Informateur);
        else
            informateurId = informateur.Id;
        denonciation.InformateurId = informateurId;

        Console.WriteLine($"Informateur Id = {informateurId}, Suspect Id = {suspectId}");

        var denonciationId = await _denonciationRepository.Create(denonciation);
        return denonciationId;
    }
}