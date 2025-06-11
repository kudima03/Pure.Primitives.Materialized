using Pure.Primitives.DateTime;
using Pure.Primitives.Time;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Pure.Primitives.Tests.DateTime;

using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;
using Time = Primitives.Time.Time;

public sealed record MaterializedDateTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        IRandomizerDateTime dateTimeRandomizer = new RandomizerDateTime(new FieldOptionsDateTime());

        IReadOnlyCollection<System.DateTime> randomDateTimes =
            Enumerable.Range(0, 1000)
                .Select(_ => System.DateTime.Parse(dateTimeRandomizer.Generate()!.Value.ToString("G"))).ToArray();

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