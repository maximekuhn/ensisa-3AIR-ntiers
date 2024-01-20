using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetInformateurByIdQuery : IRequest<Informateur>
{
    public GetInformateurByIdQuery(int informateurId)
    {
        InformateurId = informateurId;
    }

    public int InformateurId { get; }
}