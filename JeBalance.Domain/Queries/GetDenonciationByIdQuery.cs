using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetDenonciationByIdQuery : IRequest<Denonciation>
{
    public GetDenonciationByIdQuery(Guid idOpaque)
    {
        IdOpaque = idOpaque;
    }

    public Guid IdOpaque { get; }
}