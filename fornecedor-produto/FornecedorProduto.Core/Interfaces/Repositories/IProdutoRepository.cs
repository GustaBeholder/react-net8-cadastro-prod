using FornecedorProduto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Core.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<int> CreateProduto(Product produto);
        Task<IEnumerable<Product>> GetAll(string query);
        Task<Product> GetById(int id);
        Task<bool> UpdateProduto(Product product);
        Task<bool> DeleteProduto(int id);
    }
}
