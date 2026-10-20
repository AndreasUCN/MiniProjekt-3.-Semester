using System;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repositories;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Definer adressen til din lokale SQL Server database
        string connectionString = "Server=localhost;Database=MiniProjekt;Trusted_Connection=True;TrustServerCertificate=True;";

        try
        {
            Console.WriteLine("Forbinder til databasen...");

            // 2. Instansier dine DAO-klasser med stort DAO
            IAuthorDAO authorDao = new AuthorDAO(connectionString);
            IBlogPostDAO blogPostDao = new BlogPostDAO(connectionString);

            // 3. TEST FORBINDELSEN: Hent de 10 seneste blogindlæg
            Console.WriteLine("Henter data...");
            var posts = await blogPostDao.Get10LatestAsync();

            Console.WriteLine("\nFORBINDELSE SUCCES! Her er de seneste blogindlæg i databasen:");
            foreach (var post in posts)
            {
                Console.WriteLine($"- {post.PostTitle} (ID: {post.Id})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nFEJL: Kunne ikke forbinde til databasen!");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nTryk på en tast for at lukke...");
        Console.ReadKey();
    }
}