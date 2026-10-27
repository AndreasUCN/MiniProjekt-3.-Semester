using NUnit.Framework;
using System.Threading.Tasks;
using WebApiClient;

namespace Tests.WebApiClient
{
    [TestFixture]
    public class BlogSharpApiClientTests
    {
        private BlogSharpApiClient _client;

        [SetUp]
        public void Init()
        {
            _client = new BlogSharpApiClient(
                "https://localhost:7280/api/authors/20");
        }

        [Test]
        public async Task GetAuthorByIdAsync_ReturnsAuthor()
        {
            var author = await _client.GetAuthorByIdAsync(20);

            Assert.That(author, Is.Not.Null);
            Assert.That(author.Id, Is.EqualTo(20));
        }
    }
}