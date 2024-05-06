using Dapper;
using FornecedorProduto.Core.Entities;
using FornecedorProduto.Core.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace FornecedorProduto.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MySql")!;
        }

        public async Task<int> CreateUser(User usuario)
        {
            using MySqlConnection conn = new (_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"INSERT INTO usuario (nome, email, senha)
                                    VALUES (@nome, @email, @senha);
                                    SELECT LAST_INSERT_ID();";

                int id = await conn.QuerySingleAsync<int>(sqlQuery, param: usuario);

                return id;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = "SELECT * FROM usuario";
                IEnumerable<User> results = await conn.QueryAsync<User>(sqlQuery);
                conn.Close();
                return results;
            }
            catch(Exception ex) 
            {
                throw;
            }
        }
        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"SELECT * FROM usuario
                                    WHERE email = @email
                                    AND senha = @password;";

                var results = await conn.QueryFirstAsync<User>(sqlQuery, param: new { email, password });

                conn.Close();

                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"SELECT * FROM usuario
                                    WHERE id = @id";

                var results = await conn.QueryFirstAsync<User>(sqlQuery, param: new { id });

                conn.Close();

                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> UpdateUser(User usuario)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"UPDATE usuario SET nome = @nome, email = @email, senha = @senha
                                    WHERE id = @id";

                var results = await conn.QueryFirstAsync<User>(sqlQuery, param: usuario);

                conn.Close();

                return results;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
