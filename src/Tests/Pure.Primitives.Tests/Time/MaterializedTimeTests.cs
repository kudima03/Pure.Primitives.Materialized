using Pure.Primitives.Time;

namespace Pure.Primitives.Tests.Time;

using Time = Primitives.Time.Time;

public sealed record MaterializedTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        Random random = new Random();
        TimeOnly currentTime = TimeOnly.FromDateTime(System.DateTime.Now);
        IReadOnlyCollection<TimeOnly> randomTimes = Enumerable.Range(0, 1000)
            .Select(_ => currentTime.AddHours(random.Next(100)).AddMinutes(random.Next())).ToArray();

        Assert.Equal(randomTimes, randomTimes.Select(x => new MaterializedTime(new Time(x)).Value));
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