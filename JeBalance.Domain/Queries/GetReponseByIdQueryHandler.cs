using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetReponseByIdQueryHandler : IRequestHandler<GetReponseByIdQuery, Reponse>
{
    public readonly ReponseRepository _reponseRepository;
    
    public GetReponseByIdQueryHandler(ReponseRepository reponseRepository)
    {
        _reponseRepository = reponseRepository;
    }

    public async Task<Reponse> Handle(GetReponseByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.ReponseId;
        var reponse = await _reponseRepository.GetOne(id);
        return reponse;
    }
}