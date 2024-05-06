using FornecedorProduto.Application.ViewModels;
using FornecedorProduto.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Queries.Product.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProductsQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var produtos = await _produtoRepository.GetAll(request.QueryName);

            var response = new List<ProductViewModel>();

            response.AddRange(produtos.Select(produto => new ProductViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                CodigoProduto = produto.CodigoProduto,
                Preco = produto.Preco,
                CriadoPor = "teste"
            }));

            return response;
        }
    }
}
