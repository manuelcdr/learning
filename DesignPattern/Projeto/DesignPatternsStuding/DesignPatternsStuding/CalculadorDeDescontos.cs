using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class CalculadorDeDescontos
    {
        public static double CalculaDescontos(Orcamento orcamento)
        {
            var semDesconto = new SemDesconto(null);
            var d3 = new DescontoPorVendaCasada(semDesconto, new string[] { "lápis", "caneta" });
            var d2 = new DescontoPorMaisDeCincoItens(d3);
            var d1 = new DescontoPorMaisDe500Reais(d2);

            return d1.CalculaDesconto(orcamento);
        }
    }
}
