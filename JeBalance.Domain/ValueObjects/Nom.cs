using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class Nom : SimpleValueObject<string>
{
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;

    public Nom(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();

        if (string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Name cannot be empty");

        if (trimmedValue.Length < MIN_LENGTH)
            throw new ApplicationException($"Le nom doit faire au minimum {MIN_LENGTH} caractère(s)");

        if (trimmedValue.Length > MAX_LENGTH)
            throw new ApplicationException($"Le nom ne peut pas faire plus de {MAX_LENGTH} caractère(s)");

        return trimmedValue;
    }

    public override bool Equals(object? obj)
    {
        return Value == obj?.ToString();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public static implicit operator string(Nom nom)
    {
        return nom.Value;
    }

    public static implicit operator Nom(string value)
    {
        return new Nom(value);
    }
}