namespace JeBalance.Domain.Contracts;

public abstract class SimpleValueObject<T>
{
    public SimpleValueObject(T value)
    {
        Value = Validate(value);
    }

    public T Value { get; }

    public abstract T Validate(T value);
}