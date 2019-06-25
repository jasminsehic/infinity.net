using Xunit;
using Infinity.Util;

using Assert = Xunit.Assert;

namespace Infinity.Tests
{
    public class UrlHelpersFixture
    {
        [Theory]
        [InlineData("/", "/", "/")]
        [InlineData("/one", "/one", "/")]
        [InlineData("/one/two", "/one", "/two")]
        [InlineData("/one/two", "/one", "two")]
        public static void UrlHelpers_CanJoinPaths(string expected, string one, string two)
        {
            Assert.Equal(expected, UrlHelpers.JoinPath(one, two));
        }
    }
}
