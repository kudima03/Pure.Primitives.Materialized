using Pure.Primitives.Materialized.Char;

namespace Pure.Primitives.Materialized.Tests.Char;

using Char = Primitives.Char.Char;

public sealed record MaterializedCharTests
{
    [Fact]
    public void MaterializeCorrectly()
    {
        IEnumerable<char> chars =
            Enumerable.Range(char.MinValue, char.MaxValue).Select(x => (char)x).ToArray();

        IEnumerable<char> materializedChars = chars.Select(x => new Char(x)).Select(x => new MaterializedChar(x).Value);

        Assert.Equal(chars, materializedChars);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedChar(new Char('A')).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedChar(new Char('A')).ToString());
    }
}