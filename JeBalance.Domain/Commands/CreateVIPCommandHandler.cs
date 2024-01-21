using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands;

public class CreateVIPCommandHandler : IRequestHandler<CreateVIPCommand, int>
{
    private readonly VIPRepository _vipRepository;

    public CreateVIPCommandHandler(VIPRepository vipRepository)
    {
        _vipRepository = vipRepository;
    }

    public async Task<int> Handle(CreateVIPCommand request, CancellationToken cancellationToken)
    {
        var vip = request.Vip;
        var vipId = await _vipRepository.Create(vip);
        return vipId;
    }
}