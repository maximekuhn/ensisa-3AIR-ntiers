using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetDenonciationByIdQuery: IRequest<Denonciation>
{
    public Guid IdOpaque { get; }

    public GetDenonciationByIdQuery(Guid idOpaque)
    {
        IdOpaque = idOpaque;
    }
}