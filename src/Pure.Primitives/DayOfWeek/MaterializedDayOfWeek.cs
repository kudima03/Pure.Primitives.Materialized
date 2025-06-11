using Pure.Primitives.Abstractions.DayOfWeek;
using System;

namespace Pure.Primitives.DayOfWeek;

public sealed record MaterializedDayOfWeek
{
    private readonly IDayOfWeek _value;

    public MaterializedDayOfWeek(IDayOfWeek value)
    {
        _value = value;
    }

    public System.DayOfWeek Value
    {
        get
        {
            int dayNumber = _value.DayNumberValue.NumberValue;
            return dayNumber == 7 ? System.DayOfWeek.Sunday : (System.DayOfWeek)dayNumber;
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}