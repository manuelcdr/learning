using System;

namespace DesignPatternsStuding
{
    public interface IEstadoDeUmOrcamento
    {
        bool DescontoAplicado { set; }
        void AplicaDescontoExtra(Orcamento orcamento);
        void Aprova(Orcamento orcamento);
        void Reprova(Orcamento orcamento);
        void Finaliza(Orcamento orcamento);

    }

    public class EmAprovacao : IEstadoDeUmOrcamento
    {
        public bool DescontoAplicado { private get; set; }

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (DescontoAplicado) throw new Exception("Desconto já foi aplicado.");
            DescontoAplicado = true;
            orcamento.Valor -= orcamento.Valor * 0.05;
        }

        public void Aprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Aprovado();
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento precisa ser aprovado ou reprovado antes de finalizar.");
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }
    }

    public class Aprovado : IEstadoDeUmOrcamento
    {
        public bool DescontoAplicado { private get; set; }
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (DescontoAplicado) throw new Exception("Desconto já foi aplicado.");
            DescontoAplicado = true;
            orcamento.Valor -= orcamento.Valor * 0.02;
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está aprovado.");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }
    }

    public class Reprovado : IEstadoDeUmOrcamento
    {
        public bool DescontoAplicado { private get; set; }
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Desconto~não pdoe ser aplicado a um orçamento reprovado.");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está reprovado.");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está reprovado.");
        }
    }

    public class Finalizado : IEstadoDeUmOrcamento
    {
        public bool DescontoAplicado { private get; set; }
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está finalizado.");
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está finalizado.");
        }

        public void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está finalizado.");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está finalizado.");
        }
    }
}