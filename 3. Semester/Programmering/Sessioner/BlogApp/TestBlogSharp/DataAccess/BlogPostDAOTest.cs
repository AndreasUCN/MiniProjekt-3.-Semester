using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Model;
using DataAccess.Repositories;

namespace TestBlogSharp.DataAccess
{
    [TestFixture]
    public class BlogPostDAOTest
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=MiniProjekt;Trusted_Connection=True;TrustServerCertificate=True;";

        private AuthorDAO _authorDAO;
        private BlogPostDAO _blogPostDAO;
        private int _testAuthorId;

        [SetUp]
        public async Task Setup()
        {
            _authorDAO = new AuthorDAO(_connectionString);
            _blogPostDAO = new BlogPostDAO(_connectionString);

            // Ryd gamle data
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM BlogPost; DELETE FROM Author;");

            // Opret en test-forfatter, da BlogPost kræver et gyldigt AuthorId (Foreign Key)
            var author = new Author { Email = "blogger@test.dk", BlogTitle = "The Blogger" };
            _testAuthorId = await _authorDAO.CreateAsync(author, "password");
        }

        [Test]
        public async Task CreateAsync_ShouldInsertPostAndReturnId()
        {
            // Arrange
            var post = new BlogPost
            {
                AuthorId = _testAuthorId,
                PostTitle = "Mit første indlæg",
                PostContent = "Dette er indholdet af mit indlæg."
            };

            // Act
            int newPostId = await _blogPostDAO.CreateAsync(post);

            // Assert
            Assert.That(newPostId, Is.GreaterThan(0));

            var fetched = await _blogPostDAO.GetByIdAsync(newPostId);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched.PostTitle, Is.EqualTo("Mit første indlæg"));
        }

        [Test]
        public async Task GetByPartOfTitleOrContentAsync_ShouldFindMatchingPosts()
        {
            // Arrange
            var post1 = new BlogPost { AuthorId = _testAuthorId, PostTitle = "C# for begyndere", PostContent = "Lær om C#." };
            var post2 = new BlogPost { AuthorId = _testAuthorId, PostTitle = "SQL Server tips", PostContent = "Lær om databaser." };

            await _blogPostDAO.CreateAsync(post1);
            await _blogPostDAO.CreateAsync(post2);

            // Act
            var results = await _blogPostDAO.GetByPartOfTitleOrContentAsync("begyndere");

            // Assert
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.First().PostTitle, Is.EqualTo("C# for begyndere"));
        }
    }
}