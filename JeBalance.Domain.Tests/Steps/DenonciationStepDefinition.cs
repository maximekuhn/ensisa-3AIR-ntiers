using FluentAssertions;
using JeBalance.Domain.Model;
using Xunit;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class DenonciationStepDefinition
{
    private Denonciation _denonciation;
    private Exception _exception;

    private string _paysEvasion;
    private TypeDelit _typeDelit;

    [Given(@"un suspect")]
    public void GivenUnSuspect()
    {
        // ScenarioContext.StepIsPending();
    }

    [Given(@"un informateur")]
    public void GivenUnInformateur()
    {
        // ScenarioContext.StepIsPending();
    }

    [Given(@"un delit de type ""(.*)""")]
    public void GivenUnDelitDeType(TypeDelit typeDelit)
    {
        _typeDelit = typeDelit;
    }

    [Given(@"un pays d'evasion ""(.*)""")]
    public void GivenUnPaysDevasion(string paysEvasion)
    {
        _paysEvasion = paysEvasion;
    }

    [When(@"la denonciation est creee")]
    public void WhenLaDenonciationEstCreee()
    {
        try
        {
            // TODO: remove null values
            _denonciation = new Denonciation(_typeDelit, _paysEvasion, null, null);
        }
        catch (Exception exception)
        {
            _exception = exception;
        }
    }

    [Then(@"la denonciation a un identifiant")]
    public void ThenLaDenonciationAUnIdentifiant()
    {
        // ScenarioContext.StepIsPending();
    }

    [Then(@"le statut de la denonciation est ""(.*)""")]
    public void ThenLeStatutDeLaDenonciationEst(StatutDenonciation statutDenonciation)
    {
        _denonciation.Statut.Should().Be(statutDenonciation);
    }

    [Then(@"le type de delit de la denonciation est ""(.*)""")]
    public void ThenLeTypeDeDelitDeLaDenonciationEst(TypeDelit typeDelit)
    {
        _denonciation.TypeDelit.Should().Be(typeDelit);
    }

    [Then(@"le pays d'evasion est ""(.*)""")]
    public void ThenLePaysDevasionEst(string paysEvasion)
    {
        _denonciation.PaysEvasion.Should().Be(paysEvasion);
    }


    [Then(@"le message d erreur ""(.*)"" doit etre generee")]
    public void ThenLeMessageDErreurDoitEtreGeneree(string message)
    {
        Assert.NotNull(_exception);
        _exception.Should().BeOfType<ApplicationException>();
        _exception.Message.Should().Be(message);
    }
}