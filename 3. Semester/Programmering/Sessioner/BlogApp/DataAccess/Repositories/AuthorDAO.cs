using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class AuthorDAO : BaseDAO, IAuthorDAO
    {
        public AuthorDAO(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> CreateAsync(Author entity, string password)
        {
            const string sql = @"
                INSERT INTO Author (Email, BlogTitle, PasswordHash) 
                OUTPUT INSERTED.Id
                VALUES (@Email, @BlogTitle, @PasswordHash);";

            using var connection = CreateConnection();
            // QuerySingleAsync henter det genererede ID direkte i én linje
            return await connection.QuerySingleAsync<int>(sql, new
            {
                entity.Email,
                entity.BlogTitle,
                PasswordHash = password
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Author WHERE Id = @Id;";

            using var connection = CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            const string sql = "SELECT Id, Email, BlogTitle FROM Author;";

            using var connection = CreateConnection();
            // Dapper mapper automatisk kolonnerne direkte til dine Author-objekter
            return await connection.QueryAsync<Author>(sql);
        }

        public async Task<Author> GetByEmailAsync(string email)
        {
            const string sql = "SELECT Id, Email, BlogTitle FROM Author WHERE Email = @Email;";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Author>(sql, new { Email = email });
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Email, BlogTitle FROM Author WHERE Id = @Id;";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Author>(sql, new { Id = id });
        }

        public async Task<int> LoginAsync(string email, string password)
        {
            const string sql = "SELECT Id FROM Author WHERE Email = @Email AND PasswordHash = @PasswordHash;";

            using var connection = CreateConnection();
            var id = await connection.QueryFirstOrDefaultAsync<int?>(sql, new { Email = email, PasswordHash = password });
            return id ?? -1;
        }

        public async Task<bool> UpdateAsync(Author entity)
        {
            const string sql = @"
                UPDATE Author 
                SET Email = @Email, BlogTitle = @BlogTitle 
                WHERE Id = @Id;";

            using var connection = CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }

        public async Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword)
        {
            const string sql = @"
                UPDATE Author 
                SET PasswordHash = @NewPassword 
                WHERE Email = @Email AND PasswordHash = @OldPassword;";

            using var connection = CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(sql, new { email, oldPassword, newPassword });
            return rowsAffected > 0;
        }
    }
}