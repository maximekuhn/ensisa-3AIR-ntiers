using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetVIPByIdQuery : IRequest<VIP>
{
    public GetVIPByIdQuery(int vipId)
    {
        VIPId = vipId;
    }

    public int VIPId { get; }
}