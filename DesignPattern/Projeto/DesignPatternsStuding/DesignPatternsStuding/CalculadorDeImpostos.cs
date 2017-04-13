using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class CalculadorDeImpostos
    {
        public static void Calcula(Orcamento orcamento, Imposto imposto)
        {
            double valorImposto = imposto.CalculaImposto(orcamento);
            Console.WriteLine(valorImposto); 
        }
    }
}
