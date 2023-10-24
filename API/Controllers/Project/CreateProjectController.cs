using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Project.Create;
using PostgreSQL.Data.Dtos;

namespace API.Controllers.Project;

[ApiController]
[Route("projects")]
[ApiExplorerSettings(GroupName = "projects")]

public class CreateProjectController : ControllerBase
{
    private readonly ICreateProjectCommand _command;

    public CreateProjectController(ICreateProjectCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProject([FromBody] ProjectInfoDto dto)
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
