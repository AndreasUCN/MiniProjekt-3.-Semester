using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Model;

namespace DataAccess.Repositories
{
    public class BlogPostDAO : BaseDAO, IBlogPostDAO
    {
        public BlogPostDAO(string connectionstring) : base(connectionstring)
        {
        }

        public async Task<int> CreateAsync(BlogPost entity)
        {
            const string sql = @"
                INSERT INTO BlogPost (AuthorId, PostTitle, PostContent) 
                OUTPUT INSERTED.Id
                VALUES (@AuthorId, @PostTitle, @PostContent);";

            using var connection = CreateConnection();
            return await connection.QuerySingleAsync<int>(sql, entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM BlogPost WHERE Id = @Id;";

            using var connection = CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            const string sql = "SELECT Id, AuthorId, PostTitle, PostContent, PostCreationDate FROM BlogPost;";

            using var connection = CreateConnection();
            return await connection.QueryAsync<BlogPost>(sql);
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, AuthorId, PostTitle, PostContent, PostCreationDate FROM BlogPost WHERE Id = @Id;";

            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<BlogPost>(sql, new { Id = id });
        }

        public async Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(int authorId)
        {
            const string sql = "SELECT Id, AuthorId, PostTitle, PostContent, PostCreationDate FROM BlogPost WHERE AuthorId = @AuthorId;";

            using var connection = CreateConnection();
            return await connection.QueryAsync<BlogPost>(sql, new { AuthorId = authorId });
        }

        public async Task<IEnumerable<BlogPost>> Get10LatestAsync()
        {
            const string sql = "SELECT TOP (10) Id, AuthorId, PostTitle, PostContent, PostCreationDate FROM BlogPost ORDER BY PostCreationDate DESC;";

            using var connection = CreateConnection();
            return await connection.QueryAsync<BlogPost>(sql);
        }

        public async Task<IEnumerable<BlogPost>> GetByPartOfTitleOrContentAsync(string partOfTitleOrContent)
        {
            const string sql = @"
                SELECT Id, AuthorId, PostTitle, PostContent, PostCreationDate 
                FROM BlogPost 
                WHERE PostTitle LIKE @Search OR PostContent LIKE @Search;";

            using var connection = CreateConnection();
            // Dapper håndterer selv at indsætte søgestrengen sikkert
            return await connection.QueryAsync<BlogPost>(sql, new { Search = $"%{partOfTitleOrContent}%" });
        }

        public async Task<bool> UpdateAsync(BlogPost entity)
        {
            const string sql = @"
                UPDATE BlogPost 
                SET PostTitle = @PostTitle, PostContent = @PostContent 
                WHERE Id = @Id;";

            using var connection = CreateConnection();
            int rowsAffected = await connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }
    }
}