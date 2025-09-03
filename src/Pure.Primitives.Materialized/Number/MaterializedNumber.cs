using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Materialized.Number;

public sealed record MaterializedNumber<T>
    where T : System.Numerics.INumber<T>
{
    private readonly INumber<T> _number;

    public MaterializedNumber(INumber<T> number)
    {
        _number = number;
    }

    public T Value => _number.NumberValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
