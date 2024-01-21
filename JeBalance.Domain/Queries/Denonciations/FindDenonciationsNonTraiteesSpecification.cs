using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Queries.Denonciations;

public class FindDenonciationsNonTraiteesSpecification : Specification<Denonciation>
{
    public override Expression<Func<Denonciation, bool>> ToExpression()
    {
        return denonciation => denonciation.ReponseId == null;
    }
}