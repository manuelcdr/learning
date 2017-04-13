using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class NotaFiscalBuilder
    {
        private String RazaoSocial ;
        private String Cnpj;
        private double ValorTotal;
        private double Impostos;
        private IList<ItemDaNota> TodosItens = new List<ItemDaNota>();
        private string Observacoes;
        private DateTime Data;

        private AcoesAposGerarNF _acoesAposGerarNF; 

        public NotaFiscalBuilder(AcoesAposGerarNF acoesAposGerarNF)
        {
            this._acoesAposGerarNF = acoesAposGerarNF;
        }

        public NotaFiscal Constroi()
        {
            var nf = new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, TodosItens, Observacoes);

            _acoesAposGerarNF.Executa(nf);

            return nf;
        }

        public NotaFiscalBuilder ParaEmpresa(String razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder Com(String cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder Com(ItemDaNota item)
        {
            this.TodosItens.Add(item);
            this.ValorTotal += item.Valor;
            this.Impostos += item.Valor * 0.05;
            return this;
        }

        public NotaFiscalBuilder Com(IList<ItemDaNota> itens)
        {
            foreach(var item in itens)
            {
                this.TodosItens.Add(item);
                this.ValorTotal += item.Valor;
                this.Impostos += item.Valor * 0.05;
            }
            return this;
        }

        public NotaFiscalBuilder ComObs(String observacoes)
        {
            this.Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder NaDataAtual()
        {
            this.Data = DateTime.Now;
            return this;
        }

        public NotaFiscalBuilder NaData(DateTime data)
        {
            this.Data = data;
            return this;
        }
    }
}
