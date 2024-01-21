using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
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
        var vip = request.VIP;

        if (await VIPExist(vip)) throw new ApplicationException("La personne existe déjà");
        
        var vipId = await _vipRepository.Create(vip);
        return vipId;
    }

    private async Task<bool> VIPExist(VIP vip)
    {
        var finVIPSpecification =
            new FindPersonneSpecification<VIP>(vip.Nom, vip.Prenom, vip.Adresse);
        var maybeVIPExist = await _vipRepository.FindOne(finVIPSpecification);
        return maybeVIPExist != null;
    }
}