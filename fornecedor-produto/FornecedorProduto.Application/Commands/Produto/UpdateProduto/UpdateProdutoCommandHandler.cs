using FornecedorProduto.Core.Entities;
using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;


namespace FornecedorProduto.Application.Commands.Produto.UpdateProduto
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task<bool> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Product(request.Id, request.Nome, request.Descricao, request.CodigoProduto, request.Preco);

            var atualizou = await _produtoRepository.UpdateProduto(produto);

            return atualizou;
        }
    }
}
