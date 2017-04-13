using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class Orcamento
    {
        public double Valor { get; set; }

        public double Desconto { get; set; }

        public IList<Item> Itens { get; private set; }

        public IEstadoDeUmOrcamento EstadoAtual { get; set; }

        public Orcamento()
        {
            Itens = new List<Item>();
            EstadoAtual = new EmAprovacao();
        }

        public Orcamento(double valor) : this()
        {
            this.Valor = valor;
        }

        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
        }

        public void AplicaDescontoExtra()
        {
            EstadoAtual.AplicaDescontoExtra(this);
        }

        public void Aprova()
        {
            EstadoAtual.Aprova(this);
        }

        public void Reprova()
        {
            EstadoAtual.Reprova(this);
        }

        public void Finaliza()
        {
            EstadoAtual.Finaliza(this);
        }
    }
}
