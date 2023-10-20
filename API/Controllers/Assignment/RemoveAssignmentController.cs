using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Assignment.Remove;

namespace API.Controllers.Assignment;

[ApiController]
[Route("assignments")]
[ApiExplorerSettings(GroupName = "assignments")]

public class RemoveAssignmentController : ControllerBase
{
    private readonly IRemoveAssignmentCommand _command;

    public RemoveAssignmentController(IRemoveAssignmentCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveAssignment([FromBody] Guid id)
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