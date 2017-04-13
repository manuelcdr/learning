using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class ItemDaNotaBuilder
    {
        private string Nome;
        private double Valor;

        public ItemDaNotaBuilder ComNome(string nome)
        {
            this.Nome = nome;
            return this;
        }

        public ItemDaNotaBuilder ComValor(double valor)
        {
            this.Valor = valor;
            return this;
        }

        public ItemDaNota Constroi()
        {
            return new ItemDaNota(this.Nome, this.Valor);
        }
    }
}
