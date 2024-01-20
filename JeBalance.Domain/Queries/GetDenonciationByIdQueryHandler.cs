using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetDenonciationByIdQueryHandler : IRequestHandler<GetDenonciationByIdQuery, Denonciation>
{
    private readonly DenonciationRepository _denonciationRepository;

    public GetDenonciationByIdQueryHandler(DenonciationRepository denonciationRepository)
    {
        _denonciationRepository = denonciationRepository;
    }

    public async Task<Denonciation> Handle(GetDenonciationByIdQuery request, CancellationToken cancellationToken)
    {
        var idOpaque = request.IdOpaque;
        var denonciation = await _denonciationRepository.GetOne(idOpaque);
        return denonciation;
    }
}