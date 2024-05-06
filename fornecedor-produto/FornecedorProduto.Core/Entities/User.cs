using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Core.Entities
{
    public class User
    {
        public User(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public User(int id, string nome, string email, string senha, bool isAtivo)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            IsAtivo = isAtivo;
        }

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set;} = string.Empty;
        public string Senha { get; set;} = string.Empty;
        public bool IsAtivo { get; set;}

    }
}
