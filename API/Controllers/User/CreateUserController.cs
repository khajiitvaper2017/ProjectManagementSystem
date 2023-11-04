using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.User.Commands.Create;
using PostgreSQL.Data.Dtos;

namespace PmsAPI.Controllers.User;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class CreateUserController : ControllerBase
{
    private readonly IUserCreateCommandHandler _command;

    public CreateUserController(IUserCreateCommandHandler command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserInfoDto dto)
    {
        try
        {
            await _command.Handle(new UserCreateCommand(dto));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}