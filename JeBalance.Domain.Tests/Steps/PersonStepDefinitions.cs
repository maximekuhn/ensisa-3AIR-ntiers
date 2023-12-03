using FluentAssertions;

namespace JeBalance.Domain.Tests.Steps;

[Binding]
public class PersonStepDefinitions
{
    private string _address;
    private string _firstname;
    private string _lastname;
    private Person _person;

    [Given(@"the firstname is ""(.*)""")]
    public void GivenTheFirstnameIs(string firstname)
    {
        _firstname = firstname;
    }

    [Given(@"the lastname is ""(.*)""")]
    public void GivenTheLastnameIs(string lastname)
    {
        _lastname = lastname;
    }

    [Given(@"an address ""(.*)""")]
    public void GivenAnAddress(string address)
    {
        _address = address;
    }


    [When(@"the person is created")]
    public void WhenThePersonIsCreated()
    {
        _person = new Person(_firstname, _lastname, _address);
    }


    [Then(@"the person is added to the person list")]
    public void ThenThePersonIsAddedToThePersonList()
    {
        // _repository.contains(_person.Id).Should().BeTrue();
        // ScenarioContext.StepIsPending();
    }

    [Then(@"the person firstname is ""(.*)""")]
    public void ThenThePersonFirstnameIs(string firstname)
    {
        _person.Firstname.Should().Be(firstname);
    }

    [Then(@"the person lastname is ""(.*)""")]
    public void ThenThePersonLastnameIs(string lastname)
    {
        _person.Lastname.Should().Be(lastname);
    }

    [Then(@"the address is ""(.*)""")]
    public void ThenTheAddressIs(string address)
    {
        _person.Address.Should().Be(address);
    }

    private class Person
    {
        public Person(string firstname, string lastname, string address)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
        }

        public string Firstname { get; }
        public string Lastname { get; }
        public string Address { get; }
    }
}