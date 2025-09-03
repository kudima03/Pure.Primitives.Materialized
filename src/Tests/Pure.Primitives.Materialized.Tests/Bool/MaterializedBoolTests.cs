using Pure.Primitives.Bool;
using MaterializedBool = Pure.Primitives.Materialized.Bool.MaterializedBool;

namespace Pure.Primitives.Materialized.Tests.Bool;

public sealed record MaterializedBoolTests
{
    [Fact]
    public void MaterializeCorrectlyOnTrue()
    {
        Assert.True(new MaterializedBool(new True()).Value);
    }

    [Fact]
    public void MaterializeCorrectlyOnFalse()
    {
        Assert.False(new MaterializedBool(new False()).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedBool(new True()).GetHashCode()
        );
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new MaterializedBool(new True()).ToString()
        );
    }
}
