using System.Security.Cryptography;
using System.Text;

namespace FornecedorProduto.Core.Helpers
{
    public static class Criptografia
    {
        public static string CriptografarSenhaSHA256(string senha)
        {
            using SHA256 sha256 = SHA256.Create();

            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] hash = sha256.ComputeHash(bytesSenha);


            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2")); 
            }
            return builder.ToString();
        }
    }
}
