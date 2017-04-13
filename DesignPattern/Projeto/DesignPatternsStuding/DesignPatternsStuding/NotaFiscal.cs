using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class NotaFiscal
    {
        public String RazaoSocial { get; private set; }
        public String Cnpj { get; private set; }
        public DateTime DataDeEmissao { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public IList<ItemDaNota> Itens { get; private set; }
        public String Observacoes { get; private set; }

        public NotaFiscal(String razaoSocial, String cnpj, DateTime dataDeEmissao,
                      double valorBruto, double impostos, IList<ItemDaNota> itens,
                      String observacoes)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.DataDeEmissao = dataDeEmissao;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Itens = itens;
            this.Observacoes = observacoes;
        }

    }
}
