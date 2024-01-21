using JeBalance.Domain.Model;
using JeBalance.Domain.Tests.Drivers;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class ReponseStepDefinition
{
    private readonly DateTime _defaultDateTime = new(2024, 05, 17, 14, 32, 00);
    private readonly DenonciationRepositoryDriver _denonciationRepository;
    private readonly HorodatageProviderDriver _horodatageProvider;
    private readonly InformateurRepositoryDriver _informateurRepository;
    private readonly ReponseRepositoryDriver _reponseRepository;
    private readonly SuspectRepositoryDriver _suspectRepository;
    private Denonciation _denonciation;
    private Reponse _reponse;

    public ReponseStepDefinition()
    {
        _denonciationRepository = new DenonciationRepositoryDriver();
        _horodatageProvider = new HorodatageProviderDriver();
        _informateurRepository = new InformateurRepositoryDriver();
        _suspectRepository = new SuspectRepositoryDriver();
        _reponseRepository = new ReponseRepositoryDriver();
        _horodatageProvider.DateTime = _defaultDateTime;
    }

    [Given(@"une denonciation existante sans reponse")]
    public async Task GivenUneDenonciationExistanteSansReponse()
    {
        // Création d'un exemple d'informateur et de suspect
        var informateur = new Informateur("NomInformateur", "PrenomInformateur",
            new Adresse(new NumeroVoie(123), new NomVoie("Rue de l'Exemple"),
                new CodePostal(75000), new NomCommune("Paris")));
        var suspect = new Suspect("NomSuspect", "PrenomSuspect",
            new Adresse(new NumeroVoie(456), new NomVoie("Avenue de la Démonstration"),
                new CodePostal(75001), new NomCommune("Paris")));

        // Enregistrement de l'informateur et du suspect dans leurs repositories respectifs
        var informateurId = await _informateurRepository.Create(informateur);
        var suspectId = await _suspectRepository.Create(suspect);

        // Création d'une dénonciation sans réponse
        _denonciation = new Denonciation(TypeDelit.EvasionFiscale, "France", informateurId, suspectId);

        // Ajout de la dénonciation au repository
        _denonciationRepository.Create(_denonciation);
    }


    [When(@"une reponse de type ""Confirmation"" est ajoutee a la denonciation")]
    public void WhenUneReponseDeTypeConfirmationEstAjouteeALaDenonciation()
    {
        var typeReponse = TypeReponse.Confirmation;
        double? montantRetribution = 1000.0;

        var reponse = new Reponse(typeReponse, montantRetribution);

        _denonciation.ReponseId = reponse.Id;
    }

    // [Then(@"la denonciation a une reponse de type ""Confirmation""")]
    // public void ThenLaDenonciationAUneReponseDeTypeConfirmation()
    // {
    //     var reponse = _reponseRepository.GetById(_denonciation.ReponseId);
    //     reponse.Should().NotBeNull();
    //     reponse.Type.Should().Be(TypeReponse.Confirmation);
    // }
    //
    //
    // [Then(@"l'horodatage de la reponse est daté \(horodatage\)")]
    // public void ThenLHorodatageDeLaReponseEstDate()
    // {
    //     var reponse = _reponseRepository.GetById(_denonciation.ReponseId);
    //     reponse.Should().NotBeNull();
    //     reponse.Horodatage.Should().BeCloseTo(_denonciation.Horodatage, TimeSpan.FromSeconds(1));
    // }
    //
    //
    // [Then(@"la reponse contient le montant de la retribution")]
    // public void ThenLaReponseContientLeMontantDeLaRetribution()
    // {
    //     var reponse = _reponseRepository.GetById(_denonciation.ReponseId);
    //     reponse.Should().NotBeNull();
    //     reponse.MontantRetribution.Should().Be(1000.0);
    // }
}