using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Queries;

public class FindPersonneSpecification<T>: Specification<T> where T: Personne
{
    private readonly string _nom;
    private readonly string _prenom;

    public FindPersonneSpecification(Nom nom, Nom prenom)
    {
        _nom = nom;
        _prenom = prenom;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        return personne => (personne.Nom == _nom) && (personne.Prenom == _prenom);
    }
}