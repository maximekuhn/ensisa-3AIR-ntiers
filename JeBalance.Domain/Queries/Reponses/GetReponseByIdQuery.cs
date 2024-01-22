using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.Reponses;

public class GetReponseByIdQuery : IRequest<Reponse>
{
    public GetReponseByIdQuery(int reponseId)
    {
        ReponseId = reponseId;
    }

    public int ReponseId { get; }
}