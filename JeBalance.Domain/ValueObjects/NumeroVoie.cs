using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NumeroVoie : SimpleValueObject<int>
{
    private const int MIN_NUMBER = 1;
    private const int MAX_NUMBER = 54;

    public NumeroVoie(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {
        if (value < MIN_NUMBER)
            throw new ApplicationException($"Le numero de voie ne peut pas être inférieur à {MIN_NUMBER}");

        if (value > MAX_NUMBER)
            throw new ApplicationException($"Le numero de voie ne peut pas être supérieur à {MAX_NUMBER}");
        return value;
    }
}