using Pure.Primitives.Bool;

namespace Pure.Primitives.Tests.Bool;

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
        Assert.Throws<NotSupportedException>(() => new MaterializedBool(new True()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedBool(new True()).ToString());
    }
}