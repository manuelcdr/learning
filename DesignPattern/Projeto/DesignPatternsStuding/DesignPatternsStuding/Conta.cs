using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsStuding
{
    public class Conta
    {

        #region EstadoDaConta
        private interface IEstadoDeUmaConta
        {
            void Saca(Conta conta, double valor);
            void Deposita(Conta conta, double valor);
        }

        private class Negativada : IEstadoDeUmaConta
        {
            public void Deposita(Conta conta, double valor)
            {
                conta.Saldo += valor * 0.95;
                if (conta.Saldo >= 0) conta.EstadoAtual = new Positiva();
            }

            public void Saca(Conta conta, double valor)
            {
                throw new Exception("Sua conta está negativa. Não é permitido fazer saques.");
            }

        }

        private class Positiva : IEstadoDeUmaConta
        {
            public void Deposita(Conta conta, double valor)
            {
                conta.Saldo += valor * 0.98;
            }

            public void Saca(Conta conta, double valor)
            {
                conta.Saldo -= valor;
                if (conta.Saldo < 0) conta.EstadoAtual = new Negativada();
            }
        }
        #endregion

        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public DateTime DataAbertura { get; set; }
        private IEstadoDeUmaConta EstadoAtual { get; set; }

        public Conta(string titular)
        {
            this.EstadoAtual = new Positiva();
            this.Titular = titular;
            this.DataAbertura = DateTime.Today;
        }

        public Conta(string titular, DateTime dataAbertura) : this(titular)
        {
            this.DataAbertura = dataAbertura;
        }

        public Conta(string titular, DateTime dataAbertura, double saldoInicial) : this(titular, dataAbertura)
        {
            if (saldoInicial < 0)
                throw new Exception("A conta deve ser iniciada com um saldo positivo.");

            this.Titular = titular;
            this.Saldo = saldoInicial;
            this.DataAbertura = dataAbertura;
        }

        public void Deposita(double valor)
        {
            this.EstadoAtual.Deposita(this, valor);
        }

        public void Saca(double valor)
        {
            this.EstadoAtual.Saca(this, valor);
        }

        public override bool Equals(object obj)
        {
            Conta objeto = (Conta)obj;
            return (this.Titular == objeto.Titular && this.Saldo == objeto.Saldo && this.DataAbertura == objeto.DataAbertura);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(this.Titular) + Convert.ToInt32(this.Saldo) + Convert.ToInt32(this.DataAbertura);
        }
    }
}
