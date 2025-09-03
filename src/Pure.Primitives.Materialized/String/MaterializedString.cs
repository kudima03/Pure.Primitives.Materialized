using Pure.Primitives.Abstractions.String;

namespace Pure.Primitives.Materialized.String;

public sealed record MaterializedString
{
    private readonly IString _value;

    public MaterializedString(IString value)
    {
        _value = value;
    }

    public string Value => _value.TextValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
