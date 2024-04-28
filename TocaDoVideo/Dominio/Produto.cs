namespace TocaDoVideo.Dominio
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string Genero { get; set; }
        public string Tipo { get; set; }
        public string Produtora { get; set; }
        public string Autor { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
