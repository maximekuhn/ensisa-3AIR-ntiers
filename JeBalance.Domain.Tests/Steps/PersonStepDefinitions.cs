using FluentAssertions;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class PersonStepDefinitions
{
    private string _firstname;
    private string _lastname;

    [Given(@"the firstname is ""(.*)""")]
    public void GivenTheFirstnameIs(string firstname) => _firstname = firstname;

    [Given(@"the lastname is ""(.*)""")]
    public void GivenTheLastnameIs(string lastname) => _lastname = lastname;

    [Given(@"an address")]
    public void GivenAnAddress()
    {
        // ScenarioContext.StepIsPending();
    }

    [When(@"the person is created")]
    public void WhenThePersonIsCreated()
    {
        // ScenarioContext.StepIsPending();
    }

    [When(@"the person firstname is ""(.*)""")]
    public void WhenThePersonFirstnameIs(string firstname)
    {
        firstname.Should().Be(_firstname);
    }

    [When(@"the person lastname is ""(.*)""")]
    public void WhenThePersonLastnameIs(string lastname)
    {
        lastname.Should().Be(_lastname);
    }

    [Then(@"the person is added to the person list")]
    public void ThenThePersonIsAddedToThePersonList()
    {
        // ScenarioContext.StepIsPending();
    }
}