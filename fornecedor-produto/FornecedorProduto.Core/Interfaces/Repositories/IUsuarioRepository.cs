using FornecedorProduto.Core.Entities;


namespace FornecedorProduto.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<int> CreateUser(User usuario);
        Task<User> UpdateUser(User usuario);
    }
}
