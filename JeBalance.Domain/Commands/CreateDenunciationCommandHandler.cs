using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenunciationCommandHandler: IRequestHandler<CreateDenunciationCommand, int>
{
    public Task<int> Handle(CreateDenunciationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}