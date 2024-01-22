using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.VIPs;

public class DeleteVIPCommandHandler : IRequestHandler<DeleteVIPCommand, bool>
{
    private readonly VIPRepository _repository;

    public DeleteVIPCommandHandler(VIPRepository repository) => _repository = repository;
    
    public async Task<bool> Handle(DeleteVIPCommand request, CancellationToken cancellationToken)
    {
        return await _repository.Delete(request.Id);
    }
}