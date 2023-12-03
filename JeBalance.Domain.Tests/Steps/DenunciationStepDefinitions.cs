using FluentAssertions;
using JeBalance.Domain.Model;
using Xunit;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class DenunciationStepDefinitions
{
    private string _evasionCountry;
    private OffenseType _offenseType;
    private Denunciation _denunciation;
    private Exception _exception;
    
    [Given(@"a suspect")]
    public void GivenASuspect()
    {
        // ScenarioContext.StepIsPending();
    }

    [Given(@"an informant")]
    public void GivenAnInformant()
    {
        // ScenarioContext.StepIsPending();
    }

    [Given(@"an evasion country ""(.*)""")]
    public void GivenAnEvasionCountry(string evasionCountry)
    {
        _evasionCountry = evasionCountry;
    }

    [Given(@"an offense type ""(.*)""")]
    public void GivenAnOffenseType(OffenseType offenseType)
    {
        _offenseType = offenseType;
    }

    [When(@"the denunciation is created")]
    public void WhenTheDenunciationIsCreated()
    {
        try
        {
            _denunciation = new Denunciation(_offenseType, _evasionCountry);
            
        }
        catch (Exception exception)
        {
            _exception = exception;
        }
    }

    [Then(@"the denunciation has an id")]
    public void ThenTheDenunciationHasAnId()
    {
        // ScenarioContext.StepIsPending();
    }

    [Then(@"the denunciation status is ""(.*)""")]
    public void ThenTheDenunciationStatusIs(string waitingForResponse)
    {
        _denunciation.Status.Should().Be(DenunciationStatus.WaitingForResponse);
    }

    [Then(@"the denunciation offense type is ""(.*)""")]
    public void ThenTheDenunciationOffenseTypeIs(OffenseType offenseType)
    {
        _denunciation.OffenseType.Should().Be(offenseType);
    }

    [Then(@"the evasion country is ""(.*)""")]
    public void ThenTheEvasionCountryIs(string evasionCountry)
    {
        _denunciation.EvasionCountry.Should().Be(evasionCountry);
    }

    [Then(@"the error ""(.*)"" should be raised")]
    public void ThenTheErrorShouldBeRaised(string message)
    {
        Assert.NotNull(_exception);
        _exception.Should().BeOfType<ApplicationException>();
        _exception.Message.Should().Be(message);
    }
}