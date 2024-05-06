using Dapper;
using FornecedorProduto.Core.Entities;
using FornecedorProduto.Core.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FornecedorProduto.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MySql")!;
        }
        public async Task<int> CreateProduto(Product produto)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"INSERT INTO produto (nome, descricao, codigo_produto, preco, id_criador)
                                    VALUES (@Nome, @Descricao, @CodigoProduto, @Preco, @IdCriador);
                                    SELECT LAST_INSERT_ID();";

                int id = await conn.QuerySingleAsync<int>(sqlQuery, param: produto);

                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProduto(int id)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"UPDATE produto 
                                    SET 
                                        isAtivo = 0
                                    WHERE 
                                        id = @Id;";

                var response = await conn.ExecuteAsync(sqlQuery, param: new {id});

                if (response == 0) return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAll(string query)
        
        
        
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"SELECT 	Id,
                                            Nome,
		                                    Descricao,
		                                    codigo_produto AS CodigoProduto,
                                            Preco,
                                            id_criador AS IdCriador
                                            FROM produto
                                            WHERE isAtivo = 1";

                if (!string.IsNullOrEmpty(query))
                {
                    sqlQuery += $" AND Nome LIKE @query";
                }

                sqlQuery += ";";

                var produtos = await conn.QueryAsync<Product>(sqlQuery, param: new {query = $"%{query}%" });

                return produtos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Product> GetById(int id)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"SELECT 	Id,
                                            Nome,
		                                    Descricao,
		                                    codigo_produto AS CodigoProduto,
                                            Preco,
                                            id_criador AS IdCriador
                                            FROM produto
                                    WHERE id = @id;";

                var produto = await conn.QueryFirstAsync<Product>(sqlQuery, param: new {id});

                return produto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateProduto(Product product)
        {
            using MySqlConnection conn = new(_connectionString);

            try
            {
                conn.Open();

                string sqlQuery = @"UPDATE produto 
                                    SET 
                                        nome = @Nome,
                                        descricao = @Descricao,
                                        codigo_produto = @CodigoProduto,
                                        preco = @Preco
                                    WHERE 
                                        id = @Id;";

                var response = await conn.ExecuteAsync(sqlQuery, param: product);

                if(response == 0) return false;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
