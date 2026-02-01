using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dio.Bank
{
    public class Conta
    {
        private TipoConta tipoConta;
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set;}


        //Contructor
        public Conta (TipoConta tipoConta, string nome, double saldo , double credito)
        {
            this.tipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        //Metodos

        // Sacar

        public bool Sacar (double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine($"{this.Nome} notifificamos que o seu valor de {valorSaque} foi sacado com sucesso! Saldo Atual: {this.Saldo}");

            return true;
        }
        
        // Depositar

        public void Depositar (double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"{this.Nome} notificamos que o valor de {valorDeposito} foi depositado com sucesso! Saldo Atual: {this.Saldo}");
        }

        // Consultar Saldo

        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        // Transferir
        public void Transferir (double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        // ToString
        public override string ToString()
        {
            return $"Tipo Conta: {this.tipoConta}, Nome: {this.Nome}, Saldo: {this.Saldo}, Crédito: {this.Credito}";
        }
    }
}