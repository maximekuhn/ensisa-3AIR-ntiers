using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Queries;

public class FindPersonneSpecification : Specification<Personne>
{
    private readonly Adresse _adresse;
    private readonly Nom _nom;
    private readonly Nom _prenom;

    public FindPersonneSpecification(Nom nom, Nom prenom, Adresse adresse)
    {
        _nom = nom;
        _prenom = prenom;
        _adresse = adresse;
    }

    public override Expression<Func<Personne, bool>> ToExpression()
    {
        return personne => personne.Nom == _nom && personne.Prenom == _prenom && personne.Adresse == _adresse;
    }
}