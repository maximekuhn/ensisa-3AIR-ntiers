using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NomCommune : SimpleValueObject<string>
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 99;
    public NomCommune(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MIN_LENGTH)
            throw new ApplicationException($"Le nom de commune doit faire au minimum {MIN_LENGTH} caractère(s)");

        if (trimmedValue.Length > MAX_LENGTH)
            throw new ApplicationException(
                $"Le nom de commune ne peut pas excéder une longueur de plus de {MAX_LENGTH} caractères");
        
        return value;
    }
}