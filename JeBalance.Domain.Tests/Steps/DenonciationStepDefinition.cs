using FluentAssertions;
using JeBalance.Domain.Commands;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Services;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;
using Xunit;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class DenonciationStepDefinition
{
    private readonly DenonciationRepositoryDriver _denonciationRepository;
    private readonly InformateurRepositoryDriver _informateurRepository;
    private readonly SuspectRepositoryDriver _suspectRepository;
    private readonly HorodatageProviderDriver _horodatageProvider;
    private readonly IdOpaqueProviderDriver _idOpaqueProviderDriver;
    
    private readonly DateTime _defaultDateTime = new DateTime(2024, 05, 17, 14, 32, 00);
    private readonly Guid _defaultIdOpaque = Guid.Parse("64433caf-d963-43cc-9611-c8d09ef83402");
    
    private TypeDelit _typeDelit;
    private string _paysEvasion;
    private Informateur _informateur;
    private Suspect _suspect;
    private Guid _denonciationId;
    private Denonciation _denonciation;

    public DenonciationStepDefinition()
    {
        _denonciationRepository = new DenonciationRepositoryDriver();
        _informateurRepository = new InformateurRepositoryDriver();
        _suspectRepository = new SuspectRepositoryDriver();
        
        _horodatageProvider = new HorodatageProviderDriver();
        _horodatageProvider.DateTime = _defaultDateTime;
        
        _idOpaqueProviderDriver = new IdOpaqueProviderDriver();
        _idOpaqueProviderDriver.IdOpaque = _defaultIdOpaque;
    }


    [Given(@"un type de delit ""(.*)""")]
    public void GivenUnTypeDeDelit(TypeDelit typeDelit)
    {
        _typeDelit = typeDelit;
    }

    [Given(@"un pays d'evasion ""(.*)""")]
    public void GivenUnPaysDevasion(string paysEvasion)
    {
        _paysEvasion = paysEvasion;
    }

    [Given(@"un informateur")]
    public void GivenUnInformateur()
    {
        _informateur = new Informateur("Nom info", "Prenom info", createAdresse("info ville" ,"nom voie", 68000, 2));
    }

    [Given(@"un suspect")]
    public void GivenUnSuspect()
    {
        _suspect = new Suspect("Nom sus", "Prenom sus", createAdresse("sus ville", "sus voie", 69000, 2));
    }

    [When(@"la denonciation est creee")]
    public async Task WhenLaDenonciationEstCreee()
    {
        var createDenonciationCommand = new CreateDenonciationCommand(_typeDelit, _paysEvasion, _informateur, _suspect);
        var handler = new CreateDenonciationCommandHandler(_denonciationRepository, _informateurRepository,
            _suspectRepository, _horodatageProvider, _idOpaqueProviderDriver);
        _denonciationId = await handler.Handle(createDenonciationCommand, CancellationToken.None);
        _denonciation = _denonciationRepository.Denonciations.First();
        _informateur = _informateurRepository.Informateurs.First();
        _suspect = _suspectRepository.Suspects.First();
    }

    [Then(@"la denonciation est datée \(horodatage\)")]
    public void ThenLaDenonciationEstDateeHorodatage()
    {
        _denonciation.Horodatage.Should().Be(_defaultDateTime);
    }

    [Then(@"l'identifiant du suspect est le bon")]
    public void ThenLidentifiantDuSuspectEstLeBon()
    {
        _denonciation.SuspectId.Should().Be(_informateur.Id);
    }

    [Then(@"l'identifiant de l'informateur est le bon")]
    public void ThenLinformateurEstLeBon()
    {
        _denonciation.InformateurId.Should().Be(_suspect.Id);
    }

    private Adresse createAdresse(string nomCommune, string nomVoie, int codePostal, int numeroVoie)
    {
        return new Adresse(
            new NumeroVoie(numeroVoie),
            new NomVoie(nomVoie),
            new CodePostal(codePostal),
            new NomCommune(nomCommune)
            );
    }
}