using Pure.Primitives.DateTime;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using MaterializedDateTime = Pure.Primitives.Materialized.DateTime.MaterializedDateTime;

namespace Pure.Primitives.Materialized.Tests.DateTime;

using Date = Primitives.Date.Date;
using DateTime = Primitives.DateTime.DateTime;
using Time = Primitives.Time.Time;

public sealed record MaterializedDateTimeTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        IRandomizerDateTime dateTimeRandomizer = new RandomizerDateTime(
            new FieldOptionsDateTime()
        );

        IReadOnlyCollection<System.DateTime> randomDateTimes =
        [
            .. Enumerable
                .Range(0, 1000)
                .Select(_ =>
                    System.DateTime.Parse(
                        dateTimeRandomizer.Generate()!.Value.ToString("G")
                    )
                ),
        ];

        Assert.Equal(
            randomDateTimes,
            randomDateTimes.Select(x =>
                new MaterializedDateTime(
                    new DateTime(
                        new Date(DateOnly.FromDateTime(x)),
                        new Time(TimeOnly.FromDateTime(x))
                    )
                ).Value
            )
        );
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedDateTime(new CurrentDateTime()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedDateTime(new CurrentDateTime()).ToString()
        );
    }
}
