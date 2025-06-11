using Pure.Primitives.Bool;
using MaterializedBool = Pure.Primitives.Materialized.Bool.MaterializedBool;

namespace Pure.Primitives.Materialized.Tests.Bool;

public sealed record MaterializedBoolTests
{
    [Fact]
    public void MaterializeCorrectlyOnTrue()
    {
        Assert.True((bool)new MaterializedBool(new Primitives.Bool.True()).Value);
    }

    [Fact]
    public void MaterializeCorrectlyOnFalse()
    {
        Assert.False((bool)new MaterializedBool(new Primitives.Bool.False()).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedBool(new True()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedBool(new True()).ToString());
    }
}