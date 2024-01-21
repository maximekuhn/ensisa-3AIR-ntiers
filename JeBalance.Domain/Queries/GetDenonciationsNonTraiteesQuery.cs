using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetDenonciationsNonTraiteesQuery: IRequest<(IEnumerable<Denonciation> Results, int Total)>
{
    public (int Limit, int Offset) Pagination { get; }

    public GetDenonciationsNonTraiteesQuery((int Limit, int Offset) pagination)
    {
        Pagination = pagination;
    }
}