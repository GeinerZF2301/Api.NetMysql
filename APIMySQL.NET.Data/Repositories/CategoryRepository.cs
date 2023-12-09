using APIMySQL.NET.Data.DatabaseConfig;
using APIMySQL.NET.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace APIMySQL.NET.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MysqlConfiguration _connectionString;

        public CategoryRepository(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.StringConnection);
        }

        public async Task<bool> CreateCategory(Category category)
        {
            var connection = dbConnection();
            var querySql = @"INSERT INTO categories(name, description)
                                VALUES(@name, @description)";
            var affectedRows = await connection.ExecuteAsync(querySql,
            new { category.name, category.description });
            return affectedRows > 0;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var connection = dbConnection();
            var querySql = @"DELETE from categories WHERE id = @id";
            var affectedRows = await connection.ExecuteAsync(querySql, new { id });
            return affectedRows > 0;
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            var connection = dbConnection();
            var querySql = @"SELECT id,  name, description FROM categories";
            return connection.QueryAsync<Category>(querySql, new { });

        }

        public async Task<Category> GetCategoryById(int id)
        {
            using var connection = dbConnection();
            var querySql = @"SELECT id, name, description FROM categories WHERE id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Category>(querySql, new { Id = id });
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var connection = dbConnection();
            var querySql = @"UPDATE categories
                    SET name = @name, 
                    description = @description
                    WHERE id = @id";
            var affectedRows = await connection.ExecuteAsync(querySql,
                new { name = category.name, description = category.description, id = category.id });
            return affectedRows > 0;
        }

    }
}
