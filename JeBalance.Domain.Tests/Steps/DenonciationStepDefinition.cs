using FluentAssertions;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.Denonciations;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;
using Xunit;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class DenonciationStepDefinition
{
    private readonly DateTime _defaultDateTime = new(2024, 05, 17, 14, 32, 00);
    private readonly Guid _defaultIdOpaque = Guid.Parse("64433caf-d963-43cc-9611-c8d09ef83402");
    private readonly DenonciationRepositoryDriver _denonciationRepository;
    private readonly HorodatageProviderDriver _horodatageProvider;
    private readonly IdOpaqueProviderDriver _idOpaqueProviderDriver;
    private readonly InformateurRepositoryDriver _informateurRepository;
    private readonly SuspectRepositoryDriver _suspectRepository;
    private readonly VIPRepositoryDriver _vipRepository;
    private Denonciation _denonciation;
    private Guid _denonciationId;
    private IEnumerable<Denonciation> _denonciationsSansReponse;
    private ApplicationException _exception;
    private Informateur _informateur;
    private string _paysEvasion;
    private Suspect _suspect;

    private TypeDelit _typeDelit;
    private VIP _vip;

    public DenonciationStepDefinition()
    {
        _denonciationRepository = new DenonciationRepositoryDriver();
        _informateurRepository = new InformateurRepositoryDriver();
        _suspectRepository = new SuspectRepositoryDriver();
        _vipRepository = new VIPRepositoryDriver();

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
        _informateur = new Informateur("Nom info", "Prenom info", createAdresse("info ville", "nom voie", 68000, 2));
    }

    [Given(@"un suspect")]
    public void GivenUnSuspect()
    {
        _suspect = new Suspect("Nom sus", "Prenom sus", createAdresse("sus ville", "sus voie", 69000, 2));
    }

    [Given(@"un informateur calomniateur déjà enrengistré")]
    public void GivenUnInformateurCalomniateur()
    {
        _informateur = new Informateur(0, "Nom info", "Prenom info", createAdresse("info ville", "nom voie", 68000, 2),
            true);
        _informateurRepository.Create(_informateur);
    }

    [When(@"la denonciation est creee")]
    public async Task WhenLaDenonciationEstCreee()
    {
        try
        {
            var createDenonciationCommand =
                new CreateDenonciationCommand(_typeDelit, _paysEvasion, _informateur, _suspect);
            var handler = new CreateDenonciationCommandHandler(_denonciationRepository, _informateurRepository,
                _suspectRepository, _vipRepository, _horodatageProvider, _idOpaqueProviderDriver);

            _denonciationId = await handler.Handle(createDenonciationCommand, CancellationToken.None);
            _denonciation = _denonciationRepository.Denonciations.Last();
            _informateur = _informateurRepository.Informateurs.Last();
            _suspect = _suspectRepository.Suspects.Last();
        }
        catch (ApplicationException e)
        {
            _exception = e;
        }
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

    [Then(@"apparait le message d'erreur '(.*)'")]
    public void ThenApparaitLeMessageDetesPlusAutoriseACreerUneDenonciation(string message)
    {
        Assert.NotNull(_exception);
        _exception.Message.Should().Be(message);
    }

    [Then(@"la denonciation a un identifiant opaque")]
    public void ThenLaDenonciationAUnIdentifiantOpaque()
    {
        _denonciation.Id.Should().Be(_defaultIdOpaque);
    }

    [Then(@"l'informateur est ajouté à la base")]
    public void ThenLinformateurEstAjouteALaBase()
    {
        _informateurRepository.Informateurs.Contains(_informateur).Should().BeTrue();
    }

    [Then(@"le suspect est ajouté à la base")]
    public void ThenLeSuspectEstAjouteALaBase()
    {
        _suspectRepository.Suspects.Contains(_suspect).Should().BeTrue();
    }

    [Given(@"un suspect appartenant aux VIP")]
    public void GivenUnSuspectAppartenantAuxVip()
    {
        _suspect = new Suspect("Nom vip", "Prenom vip", createAdresse("vip ville", "vip voie", 6900, 2));
        _vip = new VIP("Nom vip", "Prenom vip", createAdresse("vip ville", "vip voie", 6900, 2));
        _vipRepository.Create(_vip);
    }

    [Then(@"l'informateur est marqué comme calomniateur")]
    public void ThenLinformateurEstMarqueCommeCalomniateur()
    {
        _informateur.EstCalomniateur.Should().BeTrue();
    }

    [Given(@"(.*) dénonciations créées sans réponse")]
    public async Task GivenNombreDenonciationsCreesSansReponse(int nombre)
    {
        for (var i = 0; i < nombre; i++)
        {
            var informateur = new Informateur("Informateur" + i, "Prénom",
                createAdresse("Ville" + i, "Rue" + i, 75000 + i, i + 1));
            var suspect = new Suspect("Suspect" + i, "Prénom", createAdresse("Ville" + i, "Rue" + i, 75000 + i, i + 1));
            var typeDelit = TypeDelit.DissimulationDeRevenus;

            var createDenonciationCommand = new CreateDenonciationCommand(typeDelit, null, informateur, suspect);
            var handler = new CreateDenonciationCommandHandler(_denonciationRepository, _informateurRepository,
                _suspectRepository, _vipRepository, _horodatageProvider, _idOpaqueProviderDriver);

            await handler.Handle(createDenonciationCommand, CancellationToken.None);
        }
    }

    [Given(@"(.*) d'entre elles ont reçu une réponse")]
    public async Task GivenNombreDenonciationsOntRecuUneReponse(int nombre)
    {
        var denonciationsAvecReponse = _denonciationRepository.Denonciations.Take(nombre).ToList();
        var reponseId = 0;

        foreach (var denonciation in denonciationsAvecReponse)
        {
            denonciation.ReponseId = reponseId;
            await _denonciationRepository.SetReponseId(denonciation.Id, reponseId);
            reponseId++;
        }
    }

    [When(@"nous récupérons (.*) dénonciations sans réponse à partir de la page (.*)")]
    public async Task WhenUneRequetePourRecupererLesDenonciationsSansReponseEstFaite(int limit, int page)
    {
        var pagination = (Limit: limit, Offset: page);
        var getDenonciationsNonTraiteesQuery = new GetDenonciationsNonTraiteesQuery(pagination);
        var getDenonciationsNonTraiteesQueryHandler =
            new GetDenonciationsNonTraiteesQueryHandler(_denonciationRepository);
        var result =
            await getDenonciationsNonTraiteesQueryHandler.Handle(getDenonciationsNonTraiteesQuery,
                CancellationToken.None);
        _denonciationsSansReponse = result.Results;
    }

    [Then(@"(.*) dénonciations sans réponse sont retournées")]
    public void ThenNombreDenonciationsSansReponseSontRetournes(int nombre)
    {
        _denonciationsSansReponse.Should().HaveCount(nombre);
    }


    [Then(@"(.*) dénonciations ont un ReponseId null")]
    public void ThenNombreDenonciationsOntUnReponseIdNull(int nombre)
    {
        _denonciationsSansReponse.Take(nombre).All(d => d.ReponseId == null).Should().BeTrue();
    }
}