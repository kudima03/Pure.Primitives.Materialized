using Pure.Primitives.Abstractions.Time;

namespace Pure.Primitives.Materialized.Time;

public sealed record MaterializedTime
{
    private readonly ITime _value;

    public MaterializedTime(ITime value)
    {
        _value = value;
    }

    public TimeOnly Value =>
        new TimeOnly(
            _value.Hour.NumberValue,
            _value.Minute.NumberValue,
            _value.Second.NumberValue,
            _value.Millisecond.NumberValue,
            _value.Microsecond.NumberValue
        );

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
