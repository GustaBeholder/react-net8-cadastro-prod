using FornecedorProduto.Application.ViewModels;
using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;

namespace FornecedorProduto.Application.Queries.Product.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuey, ProductViewModel>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProductByIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuey request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetById(request.Id);

            var response = new ProductViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                CodigoProduto = produto.CodigoProduto,
                Preco = produto.Preco,
                CriadoPor = "teste"
            };
 
            return response;

        }
    }
}
