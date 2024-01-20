using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NomCommune : SimpleValueObject<string>
{
    public NomCommune(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        // TODO: real validation
        return value;
    }

}