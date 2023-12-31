using JeBalance.Domain.Model;
using MediatR;

namespace JeBalance.Domain.Commands;

public class GestionnaireCreerDenonciationCommande: IRequestHandler<CreerDenonciationCommande, int>
{
    public Task<int> Handle(CreerDenonciationCommande request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}