
using MediatR;

namespace FornecedorProduto.Application.Commands.Produto.CreateProduto
{
    public class CreateProdutoCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; } 
        public string CodigoProduto { get; set; } 
        public decimal Preco { get; set; }
        public int IdCriador { get; set; }

    }
}
