using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class StreamFactory
    {
        public StreamReader GeraStreamReader()
        {
            Stream entrada = FileOpen("arquivo.txt");
            StreamReader leitor = new StreamReader(entrada);

            return leitor;
        }

        public StreamWriter GeraStreamWriter()
        {
            Stream saida = FileOpen("arquivo.txt");
            StreamWriter escritor = new StreamWriter(saida);

            return escritor;
        }

        private Stream FileOpen(string nomeArquivo)
        {
            return File.Open(nomeArquivo, FileMode.OpenOrCreate);
        }
    }
}
