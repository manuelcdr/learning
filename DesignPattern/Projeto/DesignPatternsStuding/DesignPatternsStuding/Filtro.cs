using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public abstract class Filtro
    {
        protected readonly Filtro FiltroComposto;

        public Filtro(Filtro comporFiltro)
        {
            this.FiltroComposto = comporFiltro;
        }

        public Filtro() { }
        
        public virtual IList<Conta> Filtrar(IList<Conta> contas)
        {
            List<Conta> contasFiltradas = new List<Conta>();
            contasFiltradas.AddRange(this.Filtra(contas));

            IList<Conta> contasFiltradasCompostas = this.FiltraComposto(contas);
            foreach (var conta in contasFiltradasCompostas)
            {
                if (!contasFiltradas.Contains(conta))
                contasFiltradas.Add(conta);
            }

            return contasFiltradas;
        }

        protected abstract IEnumerable<Conta> Filtra(IList<Conta> contas);

        private IList<Conta> FiltraComposto(IList<Conta> contas)
        {
            if (FiltroComposto == null) return new List<Conta>();
            return FiltroComposto.Filtrar(contas);
        }
    }

    public class FiltroComSaldoMenorQue100 : Filtro
    {
        public FiltroComSaldoMenorQue100()
        {
        }

        public FiltroComSaldoMenorQue100(Filtro comporFiltro) : base(comporFiltro)
        {
        }

        protected override IEnumerable<Conta> Filtra(IList<Conta> contas)
        {
            return contas.Where(c => c.Saldo < 100);
        }
    }

    public class FiltroComSaldoMaiorQue500Mil : Filtro
    {
        public FiltroComSaldoMaiorQue500Mil()
        {
        }

        public FiltroComSaldoMaiorQue500Mil(Filtro comporFiltro) : base(comporFiltro)
        {
        }

        protected override IEnumerable<Conta> Filtra(IList<Conta> contas)
        {
            return contas.Where(c => c.Saldo > 500000);
        }
    }

    public class FiltroAbertasMesCorrente : Filtro
    {
        public FiltroAbertasMesCorrente()
        {
        }

        public FiltroAbertasMesCorrente(Filtro comporFiltro) : base(comporFiltro)
        {
        }

        protected override IEnumerable<Conta> Filtra(IList<Conta> contas)
        {
            return contas.Where(c => c.DataAbertura.Month == DateTime.Today.Month);
        }
    }
}
