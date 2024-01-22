using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.VIPs;

public class GetVIPsQuery : IRequest<(IEnumerable<VIP> Results, int Total)>
{
    public GetVIPsQuery((int Limit, int Offset) pagination)
    {
        Pagination = pagination;
    }

    public (int Limit, int Offset) Pagination { get; }
}