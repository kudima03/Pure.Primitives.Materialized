using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Materialized.Bool;

public sealed record MaterializedBool
{
    private readonly IBool _value;

    public MaterializedBool(IBool value)
    {
        _value = value;
    }

    public bool Value => _value.BoolValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}