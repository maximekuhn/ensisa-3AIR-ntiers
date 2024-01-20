using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NumeroVoie : SimpleValueObject<int>
{
    // TODO: change back to 1
    private const int MIN_NUMBER = 0;

    public NumeroVoie(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {
        if (value < MIN_NUMBER)
            throw new ApplicationException($"Le numero de voie ne peut pas être inférieur à {MIN_NUMBER}");
        return value;
    }
}