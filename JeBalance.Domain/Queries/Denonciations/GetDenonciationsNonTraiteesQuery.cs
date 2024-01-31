using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.Denonciations;

public class GetDenonciationsNonTraiteesQuery : IRequest<(IEnumerable<Denonciation> Results, int Total)>
{
    public GetDenonciationsNonTraiteesQuery((int Limit, int Offset) pagination)
    {
        Pagination = pagination;
    }

    public (int Limit, int Offset) Pagination { get; }
}