using Microsoft.AspNetCore.Mvc;
using BlogWebAPI.DTO;
using DataAccess.Repositories;

namespace BlogWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorDAO _authorDAO;

    public AuthorsController(IConfiguration configuration)
    {
        _authorDAO = new AuthorDAO(
            configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
    {
        var author = await _authorDAO.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        return Ok(author.ToDto());
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAsync()
    {
        var authors = await _authorDAO.GetAllAsync();

        return Ok(authors.Select(a => a.ToDto()));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] AuthorDto newAuthorDto)
    {
        int id = await _authorDAO.CreateAsync(
            newAuthorDto.FromDto(),
            newAuthorDto.Password);

        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(
    int id,
    [FromBody] AuthorDto authorDtoToUpdate)
    {
        var existingAuthor = await _authorDAO.GetByIdAsync(id);

        if (existingAuthor == null)
            return NotFound();

        var author = authorDtoToUpdate.FromDto();
        author.Id = id;

        await _authorDAO.UpdateAsync(author);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthor(int id)
    {
        var author = await _authorDAO.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        await _authorDAO.DeleteAsync(id);

        return Ok();
    }

    [HttpPost("{id}/password")]
    public async Task<ActionResult> UpdatePassword(
    int id,
    [FromBody] AuthorDto passwordUpdateInfo)
    {
        var author = await _authorDAO.GetByIdAsync(id);

        if (author == null)
            return NotFound();

        await _authorDAO.UpdatePasswordAsync(
            passwordUpdateInfo.Email,
            passwordUpdateInfo.OldPassword,
            passwordUpdateInfo.NewPassword);

        return Ok();
    }
}