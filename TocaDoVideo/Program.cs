using System;
using System.Collections.Generic;
using TocaDoVideo.Dominio;

namespace TocaDoVideo
{
    public class Program
    {
        static ControleDeEstoque _controleEstoque = new ControleDeEstoque();

        static void Main(string[] args)
        {
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("*** Toca do Vídeo - Controle de Estoque ***\n\n");
            Console.WriteLine("Menu:\n");
            Console.WriteLine("[1] Novo\n" +
                              "[2] Listar Produtos\n" +
                              "[3] Remover Produtos\n" +
                              "[4] Entrada Estoque\n" +
                              "[5] Saída Estoque\n" +
                              "[0] Sair");
            Console.WriteLine("Escolha o número referente a opção desejada:\n");

            string opcao = Console.ReadLine();
            string codigo = "";

            switch (opcao)
            {
                case "1":
                    _controleEstoque.NovoProduto();
                    break;
                case "2":
                    _controleEstoque.ListarProdutos();
                    break;
                case "3":
                    Console.WriteLine("Digite o código do produto: ");
                    codigo = Console.ReadLine();
                    _controleEstoque.RemoverProduto(codigo);
                    break;
                case "4":
                    Console.WriteLine("Digite o código do produto: ");
                    codigo = Console.ReadLine();
                    _controleEstoque.EntradaEstoque(codigo);
                    break;
                case "5":
                    Console.WriteLine("Digite o código do produto: ");
                    codigo = Console.ReadLine();
                    _controleEstoque.SaidaEstoque(codigo);
                    break;
                case "0":
                    _controleEstoque.Sair();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.\n\n");
                    break;
            }

            MostrarMenu();
        }
    }
}


//[1] Novo
//[2] Listar Produtos
//[3] Remover Produtos
//[4] Entrada Estoque
//[5] Saída Estoque
//[0] Sair