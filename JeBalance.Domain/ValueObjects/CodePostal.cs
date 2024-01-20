using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class CodePostal : SimpleValueObject<int>
{
    public CodePostal(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {
        // TODO: real validation
        return value;
    }
}