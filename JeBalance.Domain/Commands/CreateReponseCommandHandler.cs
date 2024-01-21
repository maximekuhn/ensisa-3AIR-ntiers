using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using MediatR;

namespace JeBalance.Domain.Commands;

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

        var now = _horodatageProvider.GetNow();
        reponse.Horodatage = now;

        var denonciationId = request.DenonciationId;
        var denonciation = await _denonciationRepository.GetOne(denonciationId);

        var reponseId = await _reponseRepository.Create(reponse);

        denonciation.ReponseId = reponseId;

        await _denonciationRepository.Update(denonciationId, denonciation);
        return reponseId;
    }
}