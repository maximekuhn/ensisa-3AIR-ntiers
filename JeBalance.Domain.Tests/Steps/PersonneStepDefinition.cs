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
    private readonly SuspectRepositoryDriver _suspectRepository = new();
    private Denonciation _denonciation;
    private Informateur _informateur;
    private Personne _personne;
    private Suspect _suspect;

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
        _informateur = new Informateur(_personne.Nom, _personne.Prenom, _personne.Adresse, _personne.Id);
        _suspect = new Suspect("Nom sus", "Prenom sus", _personne.Adresse);

        var informateurId = await _informateurRepository.Create(_informateur);
        var suspectId = await _suspectRepository.Create(_suspect);

        var typeDelit = TypeDelit.DissimulationDeRevenus;
        _denonciation = new Denonciation(typeDelit, null, informateurId, suspectId);
        await _denonciationRepository.Create(_denonciation);
    }

    [Then(@"la personne informateur est ajoutee a la liste des informateurs")]
    public void ThenLaPersonneEstAjouteeALaListeDesInformateurs()
    {
        var informateurTrouve = _informateurRepository.Informateurs.Find(informateur => informateur.Id == _personne.Id);
        informateurTrouve.Should().NotBeNull();
    }

    [Then(@"la personne denoncee est ajoutee dans la liste des suspects")]
    public void ThenLaPersonneEstAjouteeDansLaListeDesSuspects()
    {
        var suspectTrouve = _suspectRepository.Suspects.Find(suspect => suspect.Id == _personne.Id);
        suspectTrouve.Should().NotBeNull();
    }
}