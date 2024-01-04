using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
{
    public Task<int> Handle(CreateDenonciationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}