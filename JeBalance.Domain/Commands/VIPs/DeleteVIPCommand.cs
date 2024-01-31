using MediatR;

namespace JeBalance.Domain.Commands.VIPs;

public class DeleteVIPCommand : IRequest<bool>
{
    public DeleteVIPCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}