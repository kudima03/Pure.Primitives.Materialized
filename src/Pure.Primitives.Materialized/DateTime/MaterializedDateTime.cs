using Pure.Primitives.Abstractions.DateTime;
using Pure.Primitives.Materialized.Date;
using Pure.Primitives.Materialized.Time;

namespace Pure.Primitives.Materialized.DateTime;

public sealed record MaterializedDateTime
{
    private readonly IDateTime _value;

    public MaterializedDateTime(IDateTime value)
    {
        _value = value;
    }

    public System.DateTime Value =>
        new System.DateTime(new MaterializedDate(_value).Value, new MaterializedTime(_value).Value);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}