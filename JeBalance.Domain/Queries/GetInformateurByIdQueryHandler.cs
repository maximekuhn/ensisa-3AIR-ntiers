using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetInformateurByIdQueryHandler : IRequestHandler<GetInformateurByIdQuery, Informateur>
{
    private readonly InformateurRepository _informateurRepository;

    public GetInformateurByIdQueryHandler(InformateurRepository informateurRepository)
    {
        _informateurRepository = informateurRepository;
    }

    public async Task<Informateur> Handle(GetInformateurByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.InformateurId;
        var informateur = await _informateurRepository.GetOne(id);
        return informateur;
    }
}