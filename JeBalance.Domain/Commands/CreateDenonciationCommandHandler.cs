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

        // TODO (get by prenom+nom+adresse, check calomniateur)

        var suspect = _suspectRepository.GetOne(0);
        denonciation.SuspectId = suspect.Id;

        var informateur = _informateurRepository.GetOne(0);
        denonciation.InformateurId = informateur.Id;

        var denonciationId = await _denonciationRepository.Create(denonciation);
        return denonciationId;
    }
}