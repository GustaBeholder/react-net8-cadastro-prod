using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Commands.Produto.DeleteProduto
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeleteProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            var delete = await _produtoRepository.DeleteProduto(request.Id);

            return delete;
        }
    }
}
