using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public abstract class AcoesAposGerarNF
    {
        protected AcoesAposGerarNF _acaoComposta { get; }

        public AcoesAposGerarNF(AcoesAposGerarNF acaoComposta)
        {
            this._acaoComposta = acaoComposta;
        }

        public AcoesAposGerarNF() { }

        public virtual void Executa(NotaFiscal nf)
        {
            this.ExecutaComposto(nf);
        }

        protected virtual void ExecutaComposto(NotaFiscal nf)
        {
            if (_acaoComposta != null) _acaoComposta.Executa(nf);
        }
    }

    public class EnviadorDeEmail : AcoesAposGerarNF
    {
        public EnviadorDeEmail()
        {
        }

        public EnviadorDeEmail(AcoesAposGerarNF acaoComposta) : base(acaoComposta)
        {
        }

        public override void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Envia email...");
            base.Executa(nf);
        }
    }

    public class EnviadorDeSMS : AcoesAposGerarNF
    {
        public EnviadorDeSMS()
        {
        }

        public EnviadorDeSMS(AcoesAposGerarNF acaoComposta) : base(acaoComposta)
        {
        }

        public override void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Envia SMS...");
            base.Executa(nf);
        }
    }

    public class SalvaNoBD : AcoesAposGerarNF
    {
        public SalvaNoBD()
        {
        }

        public SalvaNoBD(AcoesAposGerarNF acaoComposta) : base(acaoComposta)
        {
        }

        public override void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Salva no BD...");
            base.Executa(nf);
        }
    }

    public class Multiplicador : AcoesAposGerarNF
    {
        public double Fator { get; private set; }

        public Multiplicador(double fator)
        {
            this.Fator = fator;
        }

        public Multiplicador(AcoesAposGerarNF acaoComposta, double fator) : base(acaoComposta)
        {
            this.Fator = fator;
        }

        public override void Executa(NotaFiscal nf)
        {
            Console.WriteLine(nf.ValorBruto * Fator);
            base.Executa(nf);
        }
    }
}
