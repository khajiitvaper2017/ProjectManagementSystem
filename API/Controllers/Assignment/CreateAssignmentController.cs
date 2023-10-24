using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Assignment.Create;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.Assignment;

[ApiController]
[Route("assignments")]
[ApiExplorerSettings(GroupName = "assignments")]

public class CreateAssignmentController : ControllerBase
{
    private readonly ICreateAssignmentCommand _command;

    public CreateAssignmentController(ICreateAssignmentCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentInfoDto dto)
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