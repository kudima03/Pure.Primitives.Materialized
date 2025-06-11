using Pure.Primitives.String;
using MaterializedString = Pure.Primitives.Materialized.String.MaterializedString;

namespace Pure.Primitives.Materialized.Tests.String;

using String = Primitives.String.String;

public sealed record MaterializedStringTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        char[] randomChars = Enumerable.Range(char.MinValue, char.MaxValue).Select(x => (char)x).ToArray();
        string randomString = new string(randomChars);

        Assert.Equal(randomString, new MaterializedString(new String(randomString)).Value);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedString(new EmptyString()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedString(new EmptyString()).ToString());
    }
}