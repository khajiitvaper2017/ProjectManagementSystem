using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Task.Create;
using PostgreSQL.Commands.User.Create;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.Task;

[ApiController]
[Route("tasks")]
[ApiExplorerSettings(GroupName = "tasks")]
public class CreateTaskController : ControllerBase
{
    private readonly ICreateTaskCommand _command;

    public CreateTaskController(ICreateTaskCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTask([FromBody] TaskInfoDto dto)
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