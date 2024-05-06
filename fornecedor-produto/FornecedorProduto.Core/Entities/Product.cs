

namespace FornecedorProduto.Core.Entities
{
    public class Product
    {
        public Product(int id, string nome, string descricao, string codigoProduto, decimal preco, int idCriador)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CodigoProduto = codigoProduto;
            Preco = preco;
            IdCriador = idCriador;

        }

        public Product(int id, string nome, string descricao, string codigoProduto, decimal preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CodigoProduto = codigoProduto;
            Preco = preco;

        }
        public Product(string nome, string descricao, string codigoProduto, decimal preco, int idCriador)
        {

            Nome = nome;
            Descricao = descricao;
            CodigoProduto = codigoProduto;
            Preco = preco;
            IdCriador = idCriador;

        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string CodigoProduto { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int IdCriador { get; set; }
        public bool IsAtivo { get;  set; }

    }
}
