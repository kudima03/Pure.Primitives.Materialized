using Pure.Primitives.DayOfWeek;
using MaterializedDayOfWeek = Pure.Primitives.Materialized.DayOfWeek.MaterializedDayOfWeek;

namespace Pure.Primitives.Materialized.Tests.DayOfWeek;

public sealed record MaterializedDayOfWeekTests
{
    [Fact]
    public void MaterializeMonday()
    {
        Assert.Equal(System.DayOfWeek.Monday, new MaterializedDayOfWeek(new Monday()).Value);
    }

    [Fact]
    public void MaterializeTuesday()
    {
        Assert.Equal(System.DayOfWeek.Tuesday, new MaterializedDayOfWeek(new Tuesday()).Value);
    }

    [Fact]
    public void MaterializeWednesday()
    {
        Assert.Equal(System.DayOfWeek.Wednesday, new MaterializedDayOfWeek(new Wednesday()).Value);
    }

    [Fact]
    public void MaterializeThursday()
    {
        Assert.Equal(System.DayOfWeek.Thursday, new MaterializedDayOfWeek(new Thursday()).Value);
    }

    [Fact]
    public void MaterializeFriday()
    {
        Assert.Equal(System.DayOfWeek.Friday, new MaterializedDayOfWeek(new Friday()).Value);
    }

    [Fact]
    public void MaterializeSaturday()
    {
        Assert.Equal(System.DayOfWeek.Saturday, new MaterializedDayOfWeek(new Saturday()).Value);
    }

    [Fact]
    public void MaterializeSunday()
    {
        Assert.Equal(System.DayOfWeek.Sunday, new MaterializedDayOfWeek(new Sunday()).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedDayOfWeek(new Monday()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedDayOfWeek(new Monday()).ToString());
    }
}