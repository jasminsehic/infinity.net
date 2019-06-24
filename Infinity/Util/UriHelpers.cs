using System;

namespace Infinity.Util
{
    internal static class UrlHelpers
    {
        public static string JoinPath(string one, string two)
        {
            int oneLength = one.Length, twoStart = 0;

            while (oneLength > 0 && one[oneLength - 1] == '/')
            {
                oneLength--;
            }

            while (twoStart < two.Length && two[twoStart] == '/')
            {
                twoStart++;
            }

            if (twoStart == two.Length)
            {
                return (oneLength == 0) ? "/" : one.Substring(0, oneLength);
            }

            return String.Join("/", one.Substring(0, oneLength), two.Substring(twoStart));
        }
    }
}
