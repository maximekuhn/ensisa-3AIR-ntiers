using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Queries;

public class FindDenonciationsNonTraiteesSpecification : Specification<Denonciation>
{
    public override Expression<Func<Denonciation, bool>> ToExpression()
    {
        return denonciation => denonciation.ReponseId == null || denonciation.ReponseId == 0;
    }
}