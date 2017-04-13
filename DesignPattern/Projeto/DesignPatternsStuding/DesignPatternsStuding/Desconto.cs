using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public abstract class DescontoTemplate
    {
        protected DescontoTemplate Proximo { get; set; }

        public DescontoTemplate(DescontoTemplate proximo)
        {
            this.Proximo = proximo;
        }

        public double CalculaDesconto(Orcamento orcamento)
        {
            if (CondicaoDesconto(orcamento))
            {
                return GeraDesconto(orcamento);
            }
            return Proximo.CalculaDesconto(orcamento);
        }

        protected abstract bool CondicaoDesconto(Orcamento orcamento);
        protected abstract double GeraDesconto(Orcamento orcamento);
    }

    public class DescontoPorMaisDeCincoItens : DescontoTemplate
    {
        public DescontoPorMaisDeCincoItens(DescontoTemplate proximo) : base(proximo) { }

        protected override bool CondicaoDesconto(Orcamento orcamento)
        {
            return orcamento.Itens.Count > 5;
        }

        protected override double GeraDesconto(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }

    public class DescontoPorMaisDe500Reais: DescontoTemplate
    {
        public DescontoPorMaisDe500Reais(DescontoTemplate proximo) : base(proximo) { }

        protected override bool CondicaoDesconto(Orcamento orcamento)
        {
            return orcamento.Valor > 500;
        }

        protected override double GeraDesconto(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }
    }

    public class DescontoPorVendaCasada : DescontoTemplate
    {

        private string[] _produtos { get; set; }

        public DescontoPorVendaCasada(DescontoTemplate proximo, string[] produtos) : base(proximo)
        {
            this._produtos = produtos;
        }

        protected override bool CondicaoDesconto(Orcamento orcamento)
        {
            return this.Casou(orcamento);
        }

        protected override double GeraDesconto(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }

        private bool Casou(Orcamento orcamento) {
            bool casou = true;
            foreach (var produto in _produtos)
            {
                if (!this.Existe(produto, orcamento))
                {
                    casou = false;
                    break;
                }
            }
            return casou;
        }

        private bool Existe(string nome, Orcamento orcamento)
        {
            var itens = orcamento.Itens.Where(i => i.Nome.ToLower() == nome.ToLower());
            return itens.Count() > 0;
        }
    }

    public class SemDesconto : DescontoTemplate
    {
        public SemDesconto(DescontoTemplate proximo) : base(proximo) { }

        protected override bool CondicaoDesconto(Orcamento orcamento)
        {
            return true;
        }

        protected override double GeraDesconto(Orcamento orcamento)
        {
            return 0;
        }
    }
}
