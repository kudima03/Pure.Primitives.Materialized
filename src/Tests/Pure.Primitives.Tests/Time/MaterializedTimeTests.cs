using Pure.Primitives.Date;
using Pure.Primitives.Time;

namespace Pure.Primitives.Tests.Time;

using Date = Primitives.Date.Date;

public sealed record MaterializedTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        Random random = new Random();
        IReadOnlyCollection<DateOnly> randomDates = Enumerable.Range(0, 1000).Select(_ => DateOnly.MinValue.AddMonths(random.Next(0, 120000))).ToArray();

        Assert.Equal(randomDates, randomDates.Select(x => new MaterializedDate(new Date(x)).Value));
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedTime(new CurrentTime()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedTime(new CurrentTime()).ToString());
    }
}