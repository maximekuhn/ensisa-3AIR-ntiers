using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.VIPs;

public class GetVIPsQueryHandler : IRequestHandler<GetVIPsQuery, (IEnumerable<VIP> Results, int Total)>
{
    private readonly VIPRepository _vipRepository;

    public GetVIPsQueryHandler(VIPRepository vipRepository)
    {
        _vipRepository = vipRepository;
    }
    public async Task<(IEnumerable<VIP> Results, int Total)> Handle(GetVIPsQuery request, CancellationToken cancellationToken)
    {
        var pagination = request.Pagination;
        var (vips, total) = await _vipRepository.Find(pagination.Limit, pagination.Offset, null);
        return (vips, total);
    }
}