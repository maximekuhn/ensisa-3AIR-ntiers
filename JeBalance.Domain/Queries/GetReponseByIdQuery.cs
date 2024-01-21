using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetReponseByIdQuery : IRequest<Reponse>
{
    public GetReponseByIdQuery(int reponseId)
    {
        ReponseId = reponseId;
    }
    
    public int ReponseId { get; }
}