using Pure.Primitives.Date;

namespace Pure.Primitives.Tests.Date;

using Date = Primitives.Date.Date;

public sealed record MaterializedDateTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        DateOnly currentDate = DateOnly.FromDateTime(System.DateTime.Today);

        Assert.Equal(currentDate, new MaterializedDate(new Date(currentDate)).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedDate(new CurrentDate()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedDate(new CurrentDate()).ToString());
    }
}