using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace YourProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] AuthorDto loginvalues)
    {
        throw new NotImplementedException();
    }

}