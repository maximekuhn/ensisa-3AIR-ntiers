using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations;

public class GetDenonciationByIdQuery : IRequest<Denonciation>
{
    public GetDenonciationByIdQuery(Guid idOpaque)
    {
        IdOpaque = idOpaque;
    }

    public Guid IdOpaque { get; }
}