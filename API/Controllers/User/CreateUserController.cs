using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.User.Create;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.User;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class CreateUserController : ControllerBase
{
    private readonly ICreateUserCommand _command;

    public CreateUserController(ICreateUserCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserInfoDto dto)
    {
        try
        {
            await _command.ExecuteAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}