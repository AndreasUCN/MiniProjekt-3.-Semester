using DataAccess.Model;
using RestSharp;

namespace WebApiClient
{
    public class BlogSharpApiClient
    {
        private RestClient _restClient;

        public BlogSharpApiClient(string uri)
            => _restClient = new RestClient(new Uri(uri));

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var request = new RestRequest($"api/authors/{id}");

            var response =
                await _restClient.ExecuteGetAsync<Author>(request);

            return response.Data;
        }

        public async Task<bool> UpdateAuthorAsync(Author entity)
        {
            var request = new RestRequest("api/authors");

            request.AddJsonBody(entity);

            var response =
                await _restClient.ExecutePutAsync(request);

            return response.IsSuccessful;
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            var request = new RestRequest($"api/blogposts/{id}");

            var response =
                await _restClient.ExecuteGetAsync<BlogPost>(request);

            return response.Data;
        }

        public async Task<bool> UpdateBlogPostAsync(BlogPost entity)
        {
            var request = new RestRequest("api/blogposts");

            request.AddJsonBody(entity);

            var response =
                await _restClient.ExecutePutAsync(request);

            return response.IsSuccessful;
        }
    }
}