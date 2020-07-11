using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Funcoes
{
    public static class TratarTexto
    {
        public static string ProcurarQualquerPalavra(string strTexto)
        {
            return strTexto.Replace(" ", "%");
        }

        public static string TratarTextoSQL(string strTexto)
        {
            return strTexto.Replace("'", "''");
        }
    }
}
