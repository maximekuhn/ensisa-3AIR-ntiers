using System.Linq.Expressions;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Queries;

public class FindPersonneSpecification<T> : Specification<T> where T : Personne
{
    private readonly string _adresse;
    private readonly string _nom;
    private readonly string _prenom;

    public FindPersonneSpecification(Nom nom, Nom prenom, Adresse adresse)
    {
        _nom = nom;
        _prenom = prenom;
        _adresse = adresse;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        return personne =>
            personne.Nom == _nom && personne.Prenom == _prenom && _adresse.Equals(personne.Adresse);
    }
}