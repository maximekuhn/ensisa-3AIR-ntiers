using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetInformateurByIdQuery : IRequest<Informateur>
{
    public int InformateurId { get; }

    public GetInformateurByIdQuery(int informateurId)
    {
        InformateurId = informateurId;
    }
    
}