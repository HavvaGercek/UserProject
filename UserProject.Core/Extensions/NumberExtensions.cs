using System;
using System.Collections.Generic;
using System.Text;

namespace UserProject.Core.Extensions
{
    public static class NumberExtensions
    {
        public static int ToInt(this string number)
        {
            int result;
            int.TryParse(number, out result);
            return result;
        }
    }
}
