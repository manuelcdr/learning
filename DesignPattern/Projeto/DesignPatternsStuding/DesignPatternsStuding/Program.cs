using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NotaFiscalBuilder criador =
                    new NotaFiscalBuilder(
                        new EnviadorDeEmail(
                            new EnviadorDeSMS(
                                new SalvaNoBD(
                                    new Multiplicador(5.5)))));

                criador
                    .ParaEmpresa("Caelum")
                    .Com("123.456.789/0001-10")
                    .Com(new ItemDaNotaBuilder()
                        .ComNome("item 1")
                        .ComValor(100.0)
                        .Constroi())
                    .Com(new ItemDaNota("item 2", 200.0))
                    .Com(new ItemDaNota("item 3", 300.0))
                    .ComObs("entregar nf pessoalmente")
                    .NaDataAtual();

                NotaFiscal nf = criador.Constroi();

                Console.WriteLine(nf.ValorBruto);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}