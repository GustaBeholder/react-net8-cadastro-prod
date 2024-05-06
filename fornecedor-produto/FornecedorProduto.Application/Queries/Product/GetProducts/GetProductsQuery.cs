using FornecedorProduto.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Queries.Product.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        public GetProductsQuery(string queryName)
        {
            QueryName = queryName;
        }

        public string QueryName { get; set; }
    }
}
