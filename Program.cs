using System;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Welcome to Dio Bank!");
                Console.WriteLine("Selecione uma Opção:");
                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Criar Nova Conta");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Depositar");
                Console.WriteLine("5 - Transferir");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite sua opção: ");

                string opcaoUsuario = Console.ReadLine();

                switch (opcaoUsuario)
                {
                    case "1":
                        // Listar Contas
                        ListarContas();
                        break;
                    case "2":
                        // Criar Nova Conta
                        InserirConta();
                        break;
                    case "3":
                        // Sacar
                        Sacar();
                        break;
                    case "4":
                        // Depositar
                        break;
                    case "5":
                        // Transferir
                        break;
                    case "0":
                        Console.WriteLine("Obrigado por usar nossos serviços.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private static void ListarContas()
        {
            int totalContas = listaContas.Count;

            for (int i = 0; i < totalContas; i++)
            {
                Console.WriteLine($"{i} - {listaContas[i].ToString()}");
            }
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }


        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta: ");
            Console.WriteLine("Digite o valor segundo o tipo de conta que deseja criar:\n1 - Pessoa Fisica\n2 - Pessoa Juridica\n3 - Conta Nomina\n4- Conta Investimento");
            while (true)
            {
                int entradaTipoConta = int.Parse(Console.ReadLine());

                if (entradaTipoConta < 1 || entradaTipoConta > 4)
                {
                    Console.WriteLine("Tipo de conta invalido. Tente novamente os valores entre 1 e 4.");
                    continue;
                }

                Console.WriteLine("Digite o Nome Completo do Cliente: ");
                string entradaNome = Console.ReadLine();

                Console.WriteLine("Digite o Saldo Inicial: ");
                double entradaSaldo = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Crédito Disponível: ");
                double entradaCredito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                            nome: entradaNome,
                                            saldo: entradaSaldo,
                                            credito: entradaCredito);

                listaContas.Add(novaConta);
                Console.WriteLine($"Seja Bem Vindo ao Dio Bank! {entradaNome}, sua conta foi criada com sucesso!");
                break;
            }
        }
    }
}