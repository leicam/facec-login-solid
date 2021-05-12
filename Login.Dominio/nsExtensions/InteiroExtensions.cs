using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Dominio.nsExtensions
{
    public static class InteiroExtensions
    {
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }
    }
}