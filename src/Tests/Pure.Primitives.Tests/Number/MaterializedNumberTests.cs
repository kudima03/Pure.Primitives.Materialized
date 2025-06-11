﻿using Pure.Primitives.Char;
using Pure.Primitives.Number;
using Double = Pure.Primitives.Number.Double;

namespace Pure.Primitives.Tests.Number;

public sealed record MaterializedNumberTests
{
    [Fact]
    public void MaterializeIntCorrectly()
    {
        Random random = new Random();

        IEnumerable<int> numbers = Enumerable.Range(-100, 200).ToArray();

        IEnumerable<int> materializedNumbers =
            numbers.Select(x => new Int(x)).Select(x => new MaterializedNumber<int>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void MaterializeDoubleCorrectly()
    {
        Random random = new Random();

        IEnumerable<double> numbers = Enumerable.Range(0, 200).Select(_ => random.NextDouble()).ToArray();

        IEnumerable<double> materializedNumbers =
            numbers.Select(x => new Double(x)).Select(x => new MaterializedNumber<double>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void MaterializeLongCorrectly()
    {
        Random random = new Random();

        IEnumerable<long> numbers = Enumerable.Range(0, 200).Select(_ => random.NextInt64()).ToArray();

        IEnumerable<long> materializedNumbers =
            numbers.Select(x => new Long(x)).Select(x => new MaterializedNumber<long>(x).Value);

        Assert.Equal(numbers, materializedNumbers);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedNumber<int>(new Int(10)).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedNumber<int>(new Int(10)).ToString());
    }
}