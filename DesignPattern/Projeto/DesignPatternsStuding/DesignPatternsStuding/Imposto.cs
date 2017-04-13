using System;
using System.Linq;

namespace DesignPatternsStuding
{
    public abstract class Imposto
    {
        protected readonly Imposto ImpostoComposto;

        public Imposto(Imposto impostoComposto)
        {
            this.ImpostoComposto = impostoComposto;
        }

        public Imposto()
        {
        }

        public abstract double CalculaImposto(Orcamento orcamento);

        protected virtual double CalculaImpostoComposto(Orcamento orcamento)
        {
            if (this.ImpostoComposto == null) return 0;
            return this.ImpostoComposto.CalculaImposto(orcamento);
        }
    }

    public abstract class ImpostoTemplate : Imposto
    {
        public ImpostoTemplate(Imposto impostoComposto) : base(impostoComposto) { }
        public ImpostoTemplate() : base() { }

        public override double CalculaImposto(Orcamento orcamento)
        {
            if (CondicaoMaximaTaxacao(orcamento))
            {
                return CalculaImpostos(MaximaTaxacao(orcamento), orcamento);
            }
            return CalculaImpostos(MinimaTaxacao(orcamento), orcamento);
        }

        protected double CalculaImpostos(double imposto, Orcamento orcamento)
        {
            return imposto + this.CalculaImpostoComposto(orcamento);
        }

        protected abstract bool CondicaoMaximaTaxacao(Orcamento orcamento);
        protected abstract double MaximaTaxacao(Orcamento orcamento);
        protected abstract double MinimaTaxacao(Orcamento orcamento);
    }

    public class ISS : ImpostoTemplate
    {
        public ISS()
        {
        }

        public ISS(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return true;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return 0;
        }
    }

    public class ICMS : ImpostoTemplate
    {
        public ICMS()
        {
        }

        public ICMS(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return true;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + 50;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return 0;
        }
    }

    public class ICCC : ImpostoTemplate
    {
        public ICCC(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        public ICCC()
        {
        }

        public override double CalculaImposto(Orcamento orcamento)
        {
            if (this.MediaCondicao(orcamento))
            {
                return  this.CalculaImpostos(this.MediaTaxacao(orcamento), orcamento);
            }
            return base.CalculaImposto(orcamento);
        }

        private bool MediaCondicao(Orcamento orcamento)
        {
            return orcamento.Valor >= 1000 && orcamento.Valor <= 3000;
        }

        private double MediaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 3000;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.08 + 30;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    public class ICPP : ImpostoTemplate
    {
        public ICPP()
        {
        }

        public ICPP(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }
    }

    public class ICPM : ImpostoTemplate
    {
        public ICPM()
        {
        }

        public ICPM(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && TemProdutoMaisQueValor(orcamento, 100);
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        private bool TemProdutoMaisQueValor(Orcamento orcamento, double valor)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Preco >= 100) return true;
            }
            return false;
        }
    }

    public class IHIT : ImpostoTemplate
    {
        public IHIT()
        {
        }

        public IHIT(Imposto impostoComposto) : base(impostoComposto)
        {
        }

        protected override bool CondicaoMaximaTaxacao(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                var nome = item.Nome;
                if (orcamento.Itens.Count(x => x.Nome.Equals(nome)) >= 2) return true;
            }
            return false;
        }

        protected override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13;
        }

        protected override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Itens.Sum(x => x.Quantidade) * 0.01;
        }
    }
}