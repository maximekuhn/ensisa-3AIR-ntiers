using MediatR;

namespace JeBalance.Domain.Commands.VIPs;

public class DeleteVIPCommand : IRequest<bool>
{
    public int Id { get; }

    public DeleteVIPCommand(int id) => Id = id;
}