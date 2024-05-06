using FornecedorProduto.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Application.Queries.Product.GetProductById
{
    public class GetProductByIdQuey : IRequest<ProductViewModel>
    {
        public GetProductByIdQuey(int id)
        {
            Id = id;       
        }
        public int Id { get; set; }
    }
}
