using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Task.Remove;

namespace API.Controllers.Task;

[ApiController]
[Route("tasks")]
[ApiExplorerSettings(GroupName = "tasks")]

public class RemoveTaskController : ControllerBase
{
    private readonly IRemoveTaskCommand _command;

    public RemoveTaskController(IRemoveTaskCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveTask([FromBody] Guid id)
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