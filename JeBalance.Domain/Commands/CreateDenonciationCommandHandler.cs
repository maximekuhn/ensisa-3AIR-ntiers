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

        var suspectId = await GetOrInsertSuspect(request.Suspect);
        var informateurId = await GetOrInsertInformateur(request.Informateur);

        denonciation.SuspectId = suspectId;
        denonciation.InformateurId = informateurId;
        
        var denonciationId = await _denonciationRepository.Create(denonciation);
        return denonciationId;
    }

    private async Task<int> GetOrInsertSuspect(Suspect suspect)
    {
        var findSuspectSpecification =
            new FindPersonneSpecification<Suspect>(suspect.Nom, suspect.Prenom,
                suspect.Adresse);
        var maybeSuspect = await _suspectRepository.FindOne(findSuspectSpecification);
        int suspectId;
        if (maybeSuspect == null)
            suspectId = await _suspectRepository.Create(suspect);
        else
            suspectId = maybeSuspect.Id;
        return suspectId;
    }
    
    private async Task<int> GetOrInsertInformateur(Informateur informateur)
    {
        var findInformateurSpecification =
            new FindPersonneSpecification<Informateur>(informateur.Nom, informateur.Prenom,
                informateur.Adresse);
        var maybeSuspect = await _informateurRepository.FindOne(findInformateurSpecification);
        int suspectId;
        if (maybeSuspect == null)
            suspectId = await _informateurRepository.Create(informateur);
        else
            suspectId = maybeSuspect.Id;
        return suspectId;
    }
    
}