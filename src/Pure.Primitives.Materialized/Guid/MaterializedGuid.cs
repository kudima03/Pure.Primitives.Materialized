using Pure.Primitives.Abstractions.Guid;

namespace Pure.Primitives.Materialized.Guid;

public sealed record MaterializedGuid
{
    private readonly IGuid _value;

    public MaterializedGuid(IGuid value)
    {
        _value = value;
    }

    public System.Guid Value => _value.GuidValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}