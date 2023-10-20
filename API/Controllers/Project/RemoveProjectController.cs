using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Project.Remove;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.Project;

[ApiController]
[Route("projects")]
[ApiExplorerSettings(GroupName = "projects")]

public class RemoveProjectController : ControllerBase
{
    private readonly IRemoveProjectCommand _command;

    public RemoveProjectController(IRemoveProjectCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveProject([FromBody] Guid id)
    {
        try
        {
            await _command.ExecuteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}