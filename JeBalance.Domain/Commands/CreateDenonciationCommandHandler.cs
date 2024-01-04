using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateDenonciationCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
{
    private readonly DenonciationRepository _denonciationRepository;

    public CreateDenonciationCommandHandler(DenonciationRepository denonciationRepository)
    {
        _denonciationRepository = denonciationRepository;
    }

    public async Task<int> Handle(CreateDenonciationCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var denonciationId = await _denonciationRepository.Create(request.Denonciation);
            return denonciationId;
        }
        catch (Exception e)
        {
            throw e;
        }
        
    }
}