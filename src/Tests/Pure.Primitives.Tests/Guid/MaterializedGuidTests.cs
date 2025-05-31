using Pure.Primitives.Guid;

namespace Pure.Primitives.Tests.Guid;

using Guid = Primitives.Guid.Guid;

public sealed record MaterializedGuidTests
{
    [Fact]
    public void MaterializeIntCorrectly()
    {
        IEnumerable<System.Guid> guids = Enumerable.Range(0, 100).Select(_ => System.Guid.NewGuid()).ToArray();

        IEnumerable<System.Guid> materializedGuids =
            guids.Select(x => new Guid(x)).Select(x => new MaterializedGuid(x).Value);

        Assert.Equal(guids, materializedGuids);
    }

    [Fact]
    public void ThrowExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedGuid(new Guid()).GetHashCode());
    }

    [Fact]
    public void ThrowExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new MaterializedGuid(new Guid()).ToString());
    }
}