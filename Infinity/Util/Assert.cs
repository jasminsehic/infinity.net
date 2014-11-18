using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Infinity.Client")]
namespace Infinity.Util
{
    internal static class Assert
    {
        internal static void IsTrue(bool value, string name)
        {
            if (!value)
            {
                name = name ?? "argument";
                throw new ArgumentException(String.Format("{0} is not true", name));
            }
        }

        internal static void NotNull(object o, string name)
        {
            if (o == null)
            {
                name = name ?? "argument";
                throw new ArgumentNullException(String.Format("{0} cannot be null", name));
            }
        }

        internal static void NotNullOrEmpty(string o, string name)
        {
            Assert.NotNull(o, name);

            if (o.Length == 0)
            {
                name = name ?? "argument";
                throw new ArgumentException(String.Format("{0} cannot be empty", name));
            }
        }
    }
}