using Pure.Primitives.Number;
using Double = Pure.Primitives.Number.Double;

namespace Pure.Primitives.Materialized.Tests.Number;

public sealed record MaterializedNumberTests
{
    [Fact]
    public void MaterializeIntCorrectly()
    {
        Random random = new Random();

        IEnumerable<int> numbers = [.. Enumerable.Range(-100, 200)];

        IEnumerable<int> materializedNumbers = numbers
            .Select(x => new Int(x))
            .Select(x => new Materialized.Number.MaterializedNumber<int>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void MaterializeDoubleCorrectly()
    {
        Random random = new Random();

        IEnumerable<double> numbers =
        [
            .. Enumerable.Range(0, 200).Select(_ => random.NextDouble()),
        ];

        IEnumerable<double> materializedNumbers = numbers
            .Select(x => new Double(x))
            .Select(x => new Materialized.Number.MaterializedNumber<double>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void MaterializeLongCorrectly()
    {
        Random random = new Random();

        IEnumerable<long> numbers =
        [
            .. Enumerable.Range(0, 200).Select(_ => random.NextInt64()),
        ];

        IEnumerable<long> materializedNumbers = numbers
            .Select(x => new Long(x))
            .Select(x => new Materialized.Number.MaterializedNumber<long>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Materialized.Number.MaterializedNumber<int>(new Int(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Materialized.Number.MaterializedNumber<int>(new Int(10)).ToString()
        );
    }
}
