using FluentAssertions;
using JeBalance.Domain.Commands;
using JeBalance.Domain.Model;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class ReponseStepDefinition
{

    private readonly DenonciationRepositoryDriver _denonciationRepository = new();
    private readonly InformateurRepositoryDriver _informateurRepository = new();
    private readonly SuspectRepositoryDriver _suspectRepository = new();
    private readonly ReponseRepositoryDriver _reponseRepository = new();
    private readonly VIPRepositoryDriver _vipRepository = new();
    private readonly HorodatageProviderDriver _horodatageProvider = new();
    private readonly IdOpaqueProviderDriver _idOpaqueProvider = new();
    private readonly DateTime _defaultDateTime = new(2024, 05, 17, 14, 32, 00);

    public ReponseStepDefinition()
    {
        _horodatageProvider.DateTime = _defaultDateTime;
    }


    private Guid _denonciationId;
    private Denonciation _denonciation;
    private Reponse _reponse;
    private int _reponseId;


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
    public async Task WhenUneReponseDeTypeAvecUneRetributionDeEurosEstAjouteeALaDenonciaton(TypeReponse typeReponse, double retribution)
    {
        var createReponseCommand = new CreateReponseCommand(typeReponse, retribution, _denonciationId); 
        var createReponseCommandHandler = 
            new CreateReponseCommandHandler(_reponseRepository, _denonciationRepository, _horodatageProvider);

        _reponseId = await createReponseCommandHandler.Handle(createReponseCommand, CancellationToken.None);
        _denonciation = _denonciationRepository.Denonciations.Last();
        _reponse = _reponseRepository.Reponses.Last();
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
}