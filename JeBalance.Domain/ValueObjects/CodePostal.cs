using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class CodePostal : SimpleValueObject<int>
{
    public const int MIN_NUMBER = 1;
    public const int MAX_NUMBER = 99999;
    
    public CodePostal(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {
        if (value < MIN_NUMBER)
            throw new ApplicationException($"Le code postal ne peut pas être inférieur à {MIN_NUMBER}");

        if (value > MAX_NUMBER)
            throw new ApplicationException($"Le code postal ne peut pas être supérieur à {MAX_NUMBER}");
        
        return value;
    }
}