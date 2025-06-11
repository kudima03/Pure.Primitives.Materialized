using Pure.Primitives.Abstractions.Char;

namespace Pure.Primitives.Materialized.Char;

public sealed record MaterializedChar
{
    private readonly IChar _value;

    public MaterializedChar(IChar value)
    {
        _value = value;
    }

    public char Value => _value.CharValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}