using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using DataAccess.Model;
using DataAccess.Repositories;

namespace TestBlogSharp.DataAccess
{
    [TestFixture]
    public class AuthorDAOTest
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=MiniProjekt;Trusted_Connection=True;TrustServerCertificate=True;";

        private AuthorDAO _authorDAO;

        [SetUp]
        public async Task Setup()
        {
            _authorDAO = new AuthorDAO(_connectionString);

            // Ryd op i tabellerne før hver test, så testdata ikke hober sig op
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM BlogPost; DELETE FROM Author;");
        }

        [Test]
        public async Task CreateAsync_ShouldInsertAuthorAndReturnId()
        {
            // Arrange
            var author = new Author { Email = "test@author.dk", BlogTitle = "Min Test Blog" };

            // Act
            int newId = await _authorDAO.CreateAsync(author, "SecretPassword123");

            // Assert
            Assert.That(newId, Is.GreaterThan(0));

            var fetched = await _authorDAO.GetByIdAsync(newId);
            Assert.That(fetched, Is.Not.Null);
            Assert.That(fetched.Email, Is.EqualTo("test@author.dk"));
        }

        [Test]
        public async Task LoginAsync_WithCorrectCredentials_ShouldReturnAuthorId()
        {
            // Arrange
            var author = new Author { Email = "login@test.dk", BlogTitle = "Login Blog" };
            int authorId = await _authorDAO.CreateAsync(author, "MyPassword");

            // Act
            int loginResult = await _authorDAO.LoginAsync("login@test.dk", "MyPassword");

            // Assert
            Assert.That(loginResult, Is.EqualTo(authorId));
        }

        [Test]
        public async Task LoginAsync_WithWrongPassword_ShouldReturnMinusOne()
        {
            // Arrange
            var author = new Author { Email = "wrong@pwd.dk", BlogTitle = "Security Blog" };
            await _authorDAO.CreateAsync(author, "CorrectPassword");

            // Act
            int loginResult = await _authorDAO.LoginAsync("wrong@pwd.dk", "ForkertKode");

            // Assert
            Assert.That(loginResult, Is.EqualTo(-1));
        }
    }
}