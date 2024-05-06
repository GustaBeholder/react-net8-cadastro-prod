using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Commands.Produto.UpdateProduto
{
    public class UpdateProdutoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string CodigoProduto { get; set; }
    }
}
