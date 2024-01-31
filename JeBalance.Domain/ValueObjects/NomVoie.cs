using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NomVoie : SimpleValueObject<string>
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 99;

    public NomVoie(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();
        if (trimmedValue.Length < MIN_LENGTH)
            throw new ApplicationException($"Le nom de de la voie doit faire au minimum {MIN_LENGTH} caractère(s)");

        if (trimmedValue.Length > MAX_LENGTH)
            throw new ApplicationException(
                $"Le nom de de la voie ne peut pas excéder une longueur de plus de {MAX_LENGTH} caractères");

        return value;
    }
}