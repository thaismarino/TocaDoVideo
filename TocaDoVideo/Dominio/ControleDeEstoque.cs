using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TocaDoVideo.Dominio
{
    public class ControleDeEstoque
    {
        private List<Produto> _produtos { get; set; } = new List<Produto>();

        public void NovoProduto()
        {
            Produto produto = new Produto();

            int index = _produtos.Count();

            if(index == 0)
            {
                produto.Codigo = 1;
            }
            else
            {
                produto.Codigo = ++index;
            }

            produto.QuantidadeEstoque = 0;
            produto.DataCadastro = DateTime.Now;

            SelecionaTipo(produto);

            Console.WriteLine("Digite o nome: ");
            produto.Nome = Console.ReadLine();
            
            SolicitarPrecoProduto(produto);
            SelecionarGeneroProduto(produto);

            if (produto.Tipo == "Filme")
            {
                Console.WriteLine("Digite o Autor: \n");
                produto.Autor = Console.ReadLine();
            }

            if (produto.Tipo == "Jogo")
            {
                Console.WriteLine("Digite a produtora:\n");
                produto.Produtora = Console.ReadLine();
            }

            _produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso!\n\n");
        }

        public void ListarProdutos()
        {
            int quantidadeProdutos = _produtos.Count();

            if (quantidadeProdutos == 0)
            {
                Console.WriteLine("\nNenhum produto encontrado.\n\n");
                return;
            }

            Console.WriteLine("### Produtos ###\n\n");

            foreach (Produto produto in _produtos)
            {
                Console.WriteLine("#Código: " + produto.Codigo + " \n");
                Console.WriteLine("Data/Hora Cadastro: " + produto.DataCadastro.ToString("dd/MM/yyyy HH:mm") + "\n");
                Console.WriteLine("Nome: " + produto.Nome + "\n");
                Console.WriteLine("Preço: " + produto.Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR")) + "\n"); // Formatação de valor
                Console.WriteLine("Gênero: " + produto.Genero + "\n");
                Console.WriteLine("Tipo: " + produto.Tipo + "\n");

                if (produto.Tipo == "Filme")
                {
                    Console.WriteLine("Autor: " + produto.Autor + "\n");
                }
                else
                {
                    Console.WriteLine("Produtora: " + produto.Produtora + "\n");
                }

                Console.WriteLine("Quantidade em estoque: " + produto.QuantidadeEstoque + "\n\n");
            }
        }

        public void RemoverProduto(string codigo)
        {
            if (!int.TryParse(codigo, out int resultado))
            {
                Console.WriteLine("\nCódigo inválido\n\n");
                return;
            }

            Produto produto = _produtos.FirstOrDefault(x => x.Codigo == resultado);

            if (produto == null)
            {
                Console.WriteLine("\nNenhum produto encontado com o código informado");
                return;
            }

            _produtos.Remove(produto);
            Console.WriteLine("\nProduto removido com sucesso!\n\n");
        }

        public void EntradaEstoque(string codigo)
        {
            if (!int.TryParse(codigo, out int resultado))
            {
                Console.WriteLine("Código inválido\n\n");
                return;
            }

            Produto produto = _produtos.FirstOrDefault(x => x.Codigo == resultado);

            if (produto == null)
            {
                Console.WriteLine("\nNenhum produto encontrado com o código informado. Tente novamente.\n\n");
                return;
            }

            Console.WriteLine("Digite a quantidade de Entrada: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int qtd))
            {
                int index = _produtos.IndexOf(produto);
                produto.QuantidadeEstoque += qtd;
                _produtos[index] = produto;
                Console.WriteLine("Entrada registrada com sucesso!\n\n");
                return;
            }

            Console.WriteLine("\n Valor inválido. Tente novamente.\n\n");
            EntradaEstoque(codigo);
        }

        public void SaidaEstoque(string codigo)
        {
            if (!int.TryParse(codigo, out int resultado))
            {
                Console.WriteLine("\nCódigo inválido\n\n");
                return;
            }

            Produto produto = _produtos.FirstOrDefault(x => x.Codigo == resultado);

            if (produto == null)
            {
                Console.WriteLine("\nNenhum produto encontrado com o código informado. Tente novamente.\n\n");
                return;
            }

            Console.WriteLine("Digite a quantidade de Saída: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int qtd))
            {
                int index = _produtos.IndexOf(produto);
                produto.QuantidadeEstoque -= qtd;
                _produtos[index] = produto;
                Console.WriteLine("Saída registrada com sucesso!\n\n");
                return;
            }

            Console.WriteLine("\n Valor inválido. Tente novamente.\n\n");
            SaidaEstoque(codigo);
        }

        public void Sair()
        {
            Console.WriteLine("Programa encerrado! Até a próxima.\n\n");
        }

        private void SelecionarGeneroProduto(Produto produto)
        {
            if (produto.Tipo == "Filme")
            {
                Console.WriteLine("Selecione o gênero: \n");
                Console.WriteLine("[1] Ação e Aventura\n" +
                                  "[2] Drama\n" +
                                  "[3] Comédia romântica\n" +
                                  "[4] Ficção científica\n" +
                                  "[5] Terror");
                Console.WriteLine("Opção: ");
                string genero = Console.ReadLine();

                switch (genero)
                {
                    case "1":
                        produto.Genero = "Ação e Aventura";
                        break;
                    case "2":
                        produto.Genero = "Drama";
                        break;
                    case "3":
                        produto.Genero = "Comédia romântica";
                        break;
                    case "4":
                        produto.Genero = "Ficção científica";
                        break;
                    case "5":
                        produto.Genero = "Terror";
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n\n");
                        SelecionarGeneroProduto(produto);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Selecione o gênero: \n");
                Console.WriteLine("[1] Ação\n" +
                                  "[2] Aventura\n" +
                                  "[3] Estratégia\n" +
                                  "[4] RPG\n" +
                                  "[5] Esporte\n" +
                                  "[6] Corrida\n" +
                                  "[7] Simulação");
                Console.WriteLine("Opção: ");
                string genero = Console.ReadLine();

                switch (genero)
                {
                    case "1":
                        produto.Genero = "Ação";
                        break;
                    case "2":
                        produto.Genero = "Aventura";
                        break;
                    case "3":
                        produto.Genero = "Estratégia";
                        break;
                    case "4":
                        produto.Genero = "RPG";
                        break;
                    case "5":
                        produto.Genero = "Esporte";
                        break;
                    case "6":
                        produto.Genero = "Corrida";
                        break;
                    case "7":
                        produto.Genero = "Simulação";
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.\n\n");
                        SelecionarGeneroProduto(produto);
                        break;
                }
            }
        }

        private void SolicitarPrecoProduto(Produto produto)
        {
            Console.WriteLine("Digite o preço:\n");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double preco))
            {
                produto.Preco = preco;
                return;
            }

            Console.WriteLine("Preço inválido. Tente novamente.\n\n");
            SolicitarPrecoProduto(produto);
        }

        private void SelecionaTipo(Produto produto)
        {
            Console.WriteLine("Selecione o tipo do produto:\n");
            Console.WriteLine("[1] Filme\n[2] Jogo\n");
            Console.WriteLine("Opção: ");
            string tipo = Console.ReadLine();

            switch (tipo)
            {
                case "1":
                    produto.Tipo = "Filme";
                    break;
                case "2":
                    produto.Tipo = "Jogo";
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.\n\n");
                    SelecionaTipo(produto);
                    break;
            }
        }
    }
}
