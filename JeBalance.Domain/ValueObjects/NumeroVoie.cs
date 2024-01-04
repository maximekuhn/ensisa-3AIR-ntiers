using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NumeroVoie : SimpleValueObject<int>
{
    private const int MIN_NUMBER = 1;

    public NumeroVoie(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {
        if (value < 1) throw new ApplicationException($"Le numero de voie ne peut pas être inférieur à {MIN_NUMBER}");
        return value;
    }
}