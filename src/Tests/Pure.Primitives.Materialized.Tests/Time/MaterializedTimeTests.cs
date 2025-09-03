using Pure.Primitives.Time;
using MaterializedTime = Pure.Primitives.Materialized.Time.MaterializedTime;

namespace Pure.Primitives.Materialized.Tests.Time;

using Time = Primitives.Time.Time;

public sealed record MaterializedTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        Random random = new Random();
        TimeOnly time = new TimeOnly(
            random.Next(23),
            random.Next(59),
            random.Next(59),
            random.Next(999),
            random.Next(999)
        );
        IReadOnlyCollection<TimeOnly> randomTimes =
        [
            .. Enumerable
                .Range(0, 1000)
                .Select(_ => time.AddHours(random.Next(100)).AddMinutes(random.Next())),
        ];
        Assert.Equal(
            randomTimes,
            randomTimes.Select(x => new MaterializedTime(new Time(x)).Value)
        );
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedTime(new CurrentTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedTime(new CurrentTime()).ToString()
        );
    }
}
