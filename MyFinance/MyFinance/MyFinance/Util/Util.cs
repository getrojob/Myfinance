using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Util
{
    public class Util
    {
        public static string FormatarValorDecimal(string valor)
        {
            return valor.Replace(",", ".");
        }
    }
}

