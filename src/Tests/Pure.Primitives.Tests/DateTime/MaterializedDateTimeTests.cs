using Pure.Primitives.DateTime;
using Pure.Primitives.Time;

namespace Pure.Primitives.Tests.DateTime;

using Time = Primitives.Time.Time;
using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;

public sealed record MaterializedDateTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        Random random = new Random();

        TimeOnly time = new TimeOnly(random.Next(23),
            random.Next(59),
            random.Next(59),
            random.Next(999),
            random.Next(999));

        DateOnly date = new DateOnly(random.Next(8000), random.Next(12), random.Next(28));

        System.DateTime initialDateTime = new System.DateTime(date, time);

        IReadOnlyCollection<System.DateTime> randomDateTimes = Enumerable.Range(0, 1000)
            .Select(_ => initialDateTime
                .AddYears(random.Next(-100, 100))
                .AddMonths(random.Next(-100, 100))
                .AddDays(random.Next(-100, 100))
                .AddHours(random.Next(-100, 100))
                .AddMinutes(random.Next(-100, 100))
                .AddSeconds(random.Next(-100, 100))
                .AddMilliseconds(random.Next(-100, 100))
                .AddMicroseconds(random.Next(-100, 100)))
            .ToArray();

        Assert.Equal(randomDateTimes,
            randomDateTimes.Select(x =>
                new MaterializedDateTime(new DateTime(new Date(DateOnly.FromDateTime(x)),
                    new Time(TimeOnly.FromDateTime(x)))).Value));
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