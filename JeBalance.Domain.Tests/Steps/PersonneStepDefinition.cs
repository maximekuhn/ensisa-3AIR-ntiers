using FluentAssertions;
using JeBalance.Domain.Model;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class PersonneStepDefinition
{
    private readonly DenonciationRepositoryDriver _denonciationRepository = new();
    private readonly InformateurRepositoryDriver _informateurRepository = new();
    private Denonciation _denonciation;
    private Personne _personne;

    [Given(@"une personne")]
    public void GivenUnePersonne()
    {
        _personne = new Personne(1)
        {
            Nom = new Nom("Doe"), Prenom = new Nom("John"),
            Adresse = new Adresse(new NumeroVoie(10), new NomVoie("rue des Exemples"), new CodePostal(75000),
                new NomCommune("Paris"))
        };
    }

    [When(@"une personne cree une denonciation")]
    public async Task WhenUnePersonneCreeUneDenonciation()
    {
        var informateur = new Informateur(_personne.Nom, _personne.Prenom, _personne.Adresse, _personne.Id);

        var informateurId = await _informateurRepository.Create(informateur);

        var typeDelit = TypeDelit.DissimulationDeRevenus;
        var suspectId = 2;
        _denonciation = new Denonciation(typeDelit, null, informateurId, suspectId);
        await _denonciationRepository.Create(_denonciation);
    }

    [Then(@"la personne est ajoutee a la liste des informateurs")]
    public void ThenLaPersonneEstAjouteeALaListeDesInformateurs()
    {
        var informateurTrouve = _informateurRepository.Informateurs.Find(informateur => informateur.Id == _personne.Id);
        informateurTrouve.Should().NotBeNull();
    }
}