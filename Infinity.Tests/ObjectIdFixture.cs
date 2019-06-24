using System;
using Xunit;
using Infinity.Models;

namespace Infinity.Tests
{
    public class ObjectIdFixture
    {
        [Theory]
        [InlineData("abcd0123")]
        [InlineData("0123456789012345678901234567890123456789a")]
        [InlineData("012345678901234567890123456789012345678z")]
        public void ObjectId_ThrowsOnInvalid(string invalid)
        {
            Assert.Throws<ArgumentException>(() => { new ObjectId(invalid); });
        }

        [Theory]
        [InlineData("0000111122223333444455556666777788889999")]
        [InlineData("0123456789abcdeffedcba9876543210abdef012")]
        [InlineData("ab14fa91cd01749acb12810aca012487590acdde")]
        [InlineData("0102030405060708090a0b0c0d0e0f0102030405")]
        public void ObjectId_ToString(string id)
        {
            Assert.Equal(id, new ObjectId(id).ToString());
        }
    }
}
