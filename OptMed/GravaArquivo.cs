using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optmed
{
    public static class GravaArquivo
    {
        public static void EscreverArquivo(string NomeArquivo, string LinhaArquivo)
        {
            //System.IO.File.WriteAllText(@NomeArquivo, LinhaArquivo);
            using (StreamWriter writer = new StreamWriter(@NomeArquivo, false))
            {
                writer.Write(LinhaArquivo);
                writer.Close();
            };
        }
    }
}
