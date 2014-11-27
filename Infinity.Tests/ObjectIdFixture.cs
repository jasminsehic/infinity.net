using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Extensions;

using Infinity.Models;

namespace Infinity.Tests
{
    public class ObjectIdFixture
    {
        private const string stringOne = "ce08fe4884650f067bd5703b6a59a8b3b3c99a09";
        private const string stringTwo = "de08fe4884650f067bd5703b6a59a8b3b3c99a09";

        private static readonly byte[] shaOne = new byte[] { 206, 8, 254, 72, 132, 101, 15, 6, 123, 213, 112, 59, 106, 89, 168, 179, 179, 201, 154, 9 };


        [Theory]
        [InlineData("abcd0123")]
        [InlineData("0123456789012345678901234567890123456789a")]
        [InlineData("012345678901234567890123456789012345678z")]
        public void ObjectId_ThrowsOnInvalid(string invalid)
        {
            Assert.Throws(typeof(ArgumentException), () => { new ObjectId(invalid); });
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
