using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Commands.Produto.DeleteProduto
{
    public class DeleteProdutoCommand : IRequest<bool>
    {
        public DeleteProdutoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
