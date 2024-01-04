using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NomVoie : SimpleValueObject<string>
{
    public NomVoie(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        // TODO: real validation
        return value;
    }
}