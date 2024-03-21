using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Sam.Coach;

public class UnitTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 4, 3, 5, 8, 5, 0, 0, -3 }, new[] { -3, 3, 7, 9 })]
    [InlineData(new[] { 9, 6, 4, 5, 2, 0 }, new[] { 4, 5 })]

    [InlineData(new[] { 5, 4, 3, 2, 1 }, new[] { 1 })] 
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })] 
    [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new[] { 1 })] 
    [InlineData(new[] { 1, 2, 3, 1, 2, 3 }, new[] { 1, 2, 3 })] 
    [InlineData(new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 })]
    public async Task Can_Find(IEnumerable<int> data, IEnumerable<int> expected)
    {
        var finder = new LongestRisingSequenceFinder();
        IEnumerable<int> actual = await finder.Find(data);

        actual.Should().Equal(expected);
    }
}
