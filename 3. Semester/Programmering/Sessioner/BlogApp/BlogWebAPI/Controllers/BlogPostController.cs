using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace YourProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostController : ControllerBase
{
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPostDto>> Get(int id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPostDto>>> Get([FromQuery] int? authorId)
    {
        throw new NotImplementedException();
    }


}