using Pure.Primitives.Abstractions.Date;

namespace Pure.Primitives.Materialized.Date;

public sealed record MaterializedDate
{
    private readonly IDate _value;

    public MaterializedDate(IDate value)
    {
        _value = value;
    }

    public DateOnly Value => new DateOnly(_value.Year.NumberValue, _value.Month.NumberValue, _value.Day.NumberValue);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}