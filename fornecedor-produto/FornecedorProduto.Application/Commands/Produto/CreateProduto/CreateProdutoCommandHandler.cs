using FornecedorProduto.Core.Interfaces.Repositories;
using FornecedorProduto.Core.Entities;
using MediatR;

namespace FornecedorProduto.Application.Commands.Produto.CreateProduto
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, int>
    {
        private readonly IProdutoRepository _produtoRepository;

        public CreateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<int> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Product(request.Nome, request.Descricao, request.CodigoProduto, request.Preco, request.IdCriador);

            var id = await _produtoRepository.CreateProduto(produto);

            return id;
        }
    }
}
