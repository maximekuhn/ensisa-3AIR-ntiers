using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Queries.VIPs;

public class GetVIPIdByIdQueryHandler : IRequestHandler<GetVIPByIdQuery, VIP>
{
    private readonly VIPRepository _vipRepository;

    public GetVIPIdByIdQueryHandler(VIPRepository vipRepository)
    {
        _vipRepository = vipRepository;
    }

    public async Task<VIP> Handle(GetVIPByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.VIPId;
        var vip = await _vipRepository.GetOne(id);
        return vip;
    }
}