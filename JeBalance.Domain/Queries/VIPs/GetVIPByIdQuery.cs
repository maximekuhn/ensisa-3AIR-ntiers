using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries.VIPs;

public class GetVIPByIdQuery : IRequest<VIP>
{
    public GetVIPByIdQuery(int vipId)
    {
        VIPId = vipId;
    }

    public int VIPId { get; }
}