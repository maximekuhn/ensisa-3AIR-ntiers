using FluentAssertions;
using JeBalance.Domain.Commands.Denonciations;
using JeBalance.Domain.Commands.Reponses;
using JeBalance.Domain.Model;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;
using Xunit;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class ReponseStepDefinition
{
    private readonly DateTime _defaultDateTime = new(2024, 05, 17, 14, 32, 00);

    private readonly DenonciationRepositoryDriver _denonciationRepository = new();
    private readonly HorodatageProviderDriver _horodatageProvider = new();
    private readonly IdOpaqueProviderDriver _idOpaqueProvider = new();
    private readonly InformateurRepositoryDriver _informateurRepository = new();
    private readonly ReponseRepositoryDriver _reponseRepository = new();
    private readonly SuspectRepositoryDriver _suspectRepository = new();
    private readonly VIPRepositoryDriver _vipRepository = new();
    private Denonciation _denonciation;


    private Guid _denonciationId;
    private ApplicationException _exception;
    private Reponse _reponse;
    private int _reponseId;

    public ReponseStepDefinition()
    {
        _horodatageProvider.DateTime = _defaultDateTime;
    }


    [Given(@"une dénonciation existante sans réponse")]
    public async Task GivenUneDenonciationExistanteSansReponse()
    {
        var informateur = new Informateur("Doe", "John",
            new Adresse(new NumeroVoie(19), new NomVoie("rue de NullPointerException"), new CodePostal(68000),
                new NomCommune("Mulhouse")));
        var suspect = new Suspect("Smith", "Jane",
            new Adresse(new NumeroVoie(4), new NomVoie("rue de ParseIntError"), new CodePostal(67000),
                new NomCommune("Strasbourg")));
        var typeDelit = TypeDelit.DissimulationDeRevenus;

        var createDenonciationCommand = new CreateDenonciationCommand(typeDelit, null, informateur, suspect);
        var createDenonciationCommandHandler = new CreateDenonciationCommandHandler(_denonciationRepository,
            _informateurRepository, _suspectRepository, _vipRepository, _horodatageProvider, _idOpaqueProvider);

        await createDenonciationCommandHandler.Handle(createDenonciationCommand, CancellationToken.None);
    }

    [When(@"une réponse de type '(.*)'  avec une retribution de '(.*)' euros est ajoutée à la dénonciaton")]
    public async Task WhenUneReponseDeTypeAvecUneRetributionDeEurosEstAjouteeALaDenonciaton(TypeReponse typeReponse,
        double retribution)
    {
        try
        {
            var createReponseCommand = new CreateReponseCommand(typeReponse, retribution, _denonciationId);
            var createReponseCommandHandler =
                new CreateReponseCommandHandler(_denonciationRepository, _horodatageProvider, _reponseRepository,
                    _informateurRepository);

            _reponseId = await createReponseCommandHandler.Handle(createReponseCommand, CancellationToken.None);
            _denonciation = _denonciationRepository.Denonciations.Last();
            _reponse = _reponseRepository.Reponses.Last();
        }
        catch (ApplicationException e)
        {
            _exception = e;
        }
    }

    [Then(@"la dénonciation contient l'identifiant de la réponse")]
    public void ThenLaDenonciationContientLidentifiantDeLaReponse()
    {
        _denonciation.ReponseId.Should().Be(_reponseId);
    }

    [Then(@"la réponse est de type '(.*)'")]
    public void ThenLaReponseEstDeType(TypeReponse typeReponse)
    {
        _reponse.TypeReponse.Should().Be(typeReponse);
    }

    [Then(@"la réponse contient une retribution de '(.*)' euros")]
    public void ThenLaReponseContientUneRetributionDeEuros(double retribution)
    {
        _reponse.Retribution.Should().Be(retribution);
    }

    [Then(@"la réponse est datée \(horodatage\)")]
    public void ThenLaReponseEstDateeHorodatage()
    {
        _reponse.Horodatage.Should().Be(_defaultDateTime);
    }

    [Then(@"apparait le message d erreur '(.*)'")]
    public void ThenApparaitLeMessageDErreur(string message)
    {
        Assert.NotNull(_exception);
        _exception.Message.Should().Be(message);
    }

    [When(@"une réponse de type '(.*)' est ajoutée à la dénonciation")]
    public async Task WhenUneReponseDeTypeEstAjouteeALaDenonciation(TypeReponse typeReponse)
    {
        try
        {
            var createReponseCommand = new CreateReponseCommand(typeReponse, null, _denonciationId);
            var createReponseCommandHandler =
                new CreateReponseCommandHandler(_denonciationRepository, _horodatageProvider, _reponseRepository,
                    _informateurRepository);

            _reponseId = await createReponseCommandHandler.Handle(createReponseCommand, CancellationToken.None);
            _denonciation = _denonciationRepository.Denonciations.Last();
            _reponse = _reponseRepository.Reponses.Last();
        }
        catch (ApplicationException e)
        {
            _exception = e;
        }
    }

    [Then(@"la réponse contient une retribution nulle")]
    public void ThenLaReponseContientUneRetributionNulle()
    {
        Assert.Null(_reponse.Retribution);
    }

    [Given(@"une dénonciation existante avec une réponse")]
    public async Task GivenUneDenonciationExistanteAvecUneReponse()
    {
        await GivenUneDenonciationExistanteSansReponse();
        await WhenUneReponseDeTypeAvecUneRetributionDeEurosEstAjouteeALaDenonciaton(TypeReponse.Confirmation, 149.0);
    }
}