using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.User.Commands.Create;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Mediator;

namespace PmsAPI.Controllers.User;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public class CreateUserController : ControllerBase
{
    private readonly IUserCreateCommandHandler _command;

    private readonly IEmailMediator? _emailMediator;

    public CreateUserController(IUserCreateCommandHandler command, IEmailMediator? emailMediator = null)
    {
        _command = command;
        _emailMediator = emailMediator;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserInfoDto dto)
    {
        try
        {
            await _command.Handle(new UserCreateCommand(dto));
            
            await _emailMediator?.SendEmailAsync(dto.Email, "Welcome to PMS", $"{dto.FirstName} {dto.LastName}, welcome to PMS");

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}