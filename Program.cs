using System;
using System.Collections.Generic;

namespace c_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n<--- Bem vindo a TOTVS Bites --->\nQual é seu nome?");
            Usuario usuario = new Usuario();
            usuario.NomearUsuario(Console.ReadLine());

            Console.WriteLine($"<--- Olá {usuario.RetornaNomeUsuario()}! Por favor cadastre seus lanches em nossa loja virtual --->\nObservação: Máximo de 10 lanches");

            //Usei list ao invés de array
            List<Lanche> lanches = new List<Lanche>();
            List<Pedido> pedidos = new List<Pedido>();

            //Cadastro de Lanches
            do
            {
                Lanche lanche = new Lanche();

                if (lanches.Count >= 10)
                {
                    Console.WriteLine("Você atingiu o limite máximo de 10 lanches!");
                    break;
                }

                Console.WriteLine("\nQual o nome de seu lanche?");
                lanche.NomearLanche(Console.ReadLine());
                Console.WriteLine("Qual as informações sobre o lanche?");
                lanche.DescreverLanche(Console.ReadLine());
                Console.WriteLine("Qual o valor desse lanche?");
                lanche.PrecificarLanche(double.Parse(Console.ReadLine()));

                Console.WriteLine("Seu lanche foi cadastrado!");

                lanches.Add(lanche);

                Console.Write("Deseja continuar cadastrando? (S/N)");

            } while (char.ToUpper(Console.ReadLine()[0]) == 'S');

            Console.WriteLine($"{usuario.RetornaNomeUsuario()}, Finalizamos seu cadastro!\n\n\n <--- Cardápio TOTVS Bites: --- >");

            //Impressão dos lanches cadastrados
            int i = 1;
            foreach (Lanche lanche in lanches)
            {
                Console.WriteLine($"N°{i++} - Nome: {lanche.RetornaNomeLanche()}, Descrição: {lanche.RetornaDescricaoLanche()}, Preço: {lanche.RetornaPrecoLanche()}");
            }

            //Realizar pedido
            do
            {
                int indiceLanche = 1;
                Console.WriteLine("Escolha um lanche (N°): ");
                indiceLanche = int.Parse(Console.ReadLine());

                if (indiceLanche <= 0 || indiceLanche > lanches.Count)
                {
                    Console.WriteLine("Esse lanche não existe!");

                }
                else
                {
                    Pedido pedido = new Pedido();
                    pedido.lanche = lanches[indiceLanche - 1];

                    Console.WriteLine($"Qual a quantidade você quer para o lanche {lanches[indiceLanche - 1].RetornaNomeLanche()}?");
                    pedido.quantidade = int.Parse(Console.ReadLine());

                    pedidos.Add(pedido);
                }

                Console.WriteLine("Deseja fazer outro pedido além desse? (S/N)");
            } while (char.ToUpper(Console.ReadLine()[0]) == 'S');

            double valorTotalPedido = 0;

            //Impressão do pedido e cálculo dos valores
            Console.WriteLine("\n\n<-- Seu pedido: -->");
            for (int a = 0; a < pedidos.Count; a++)
            {
                double valorItem = pedidos[a].lanche.RetornaPrecoLanche() * pedidos[a].quantidade;
                valorTotalPedido += valorItem;
                Console.WriteLine($"Lanche: {pedidos[a].lanche.RetornaNomeLanche()}, Quantidade: {pedidos[a].quantidade}");
            }

            //Cálculo do serviço prestado
            double porcentagem = 7;
            double valorComServico = valorTotalPedido * (porcentagem / 100);
            double valorFinal = valorTotalPedido + valorComServico;

            Console.WriteLine($"Soma do pedido: R$ {valorTotalPedido:F2}");
            Console.WriteLine($"\n<--- Total a pagar com 7% do serviço: R$ {valorFinal:F2} --->\n\n");
            Console.WriteLine($"Volte sempre!");
        }

        public class Lanche
        {
            private string nome;
            private string descricao;
            private double preco;

            public void NomearLanche(string nomeLanche)
            {
                this.nome = nomeLanche;
            }

            public string RetornaNomeLanche()
            {
                return this.nome;
            }

            public void DescreverLanche(string descricaoLanche)
            {
                this.descricao = descricaoLanche;
            }

            public string RetornaDescricaoLanche()
            {
                return this.descricao;
            }

            public void PrecificarLanche(double precoLanche)
            {
                this.preco = precoLanche;
            }

            public double RetornaPrecoLanche()
            {
                return this.preco;
            }
        }

        public class Usuario
        {
            private string nome;

            public void NomearUsuario(string nomeUsuario)
            {
                this.nome = nomeUsuario;
            }

            public string RetornaNomeUsuario()
            {
                return this.nome;
            }
        }

        public class Pedido
        {
            public Lanche lanche;
            public int quantidade;
        }
    }
}