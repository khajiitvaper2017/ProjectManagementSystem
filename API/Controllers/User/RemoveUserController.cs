using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.User.Remove;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.User;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class RemoveUserController : ControllerBase
{
    private readonly IRemoveUserCommand _command;

    public RemoveUserController(IRemoveUserCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveUser([FromBody] Guid id)
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