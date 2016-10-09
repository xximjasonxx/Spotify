using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> enumeration, string glue)
        {
            var sb = new StringBuilder();
            var isFirst = true;

            foreach (var item in enumeration)
            {
                if (!isFirst)
                    sb.Append(glue);

                sb.Append(item.ToString());
                isFirst = false;
            }

            return sb.ToString();
        }
    }
}
