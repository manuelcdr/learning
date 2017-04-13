using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class RealizadorDeInvestimentos
    {
        public static void CalculaInvestimento(Conta conta, IInvestidor investidor)
        {
            Console.WriteLine("Saldo atual: " + conta.Saldo);
            double jurosInvestimento = investidor.Calcula(conta.Saldo);
            conta.Deposita(jurosInvestimento * 0.75);
            Console.WriteLine("Novo saldo: " + conta.Saldo);
        }
    }
}
