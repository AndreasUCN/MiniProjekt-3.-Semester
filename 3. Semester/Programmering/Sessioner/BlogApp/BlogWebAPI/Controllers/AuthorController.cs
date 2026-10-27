using Microsoft.AspNetCore.Mvc;
using BlogWebAPI.DTO;
using DataAccess.Repositories;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace BlogWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    IAuthorDAO _authorDAO;

    public AuthorsController(IConfiguration configuration)
    {
        _authorDAO = new AuthorDAO(configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthor(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthor(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAsync()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AuthorDto newAuthorDto)
    {
        throw new NotImplementedException();
    }


    [HttpPut]

    public async Task<ActionResult> Put(int id, [FromBody] AuthorDto authorDtoToUpdate)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> UpdatePassword(int id, [FromBody] AuthorDto passwordUpdateInfo)
    {
        throw new NotImplementedException();

    }
}
