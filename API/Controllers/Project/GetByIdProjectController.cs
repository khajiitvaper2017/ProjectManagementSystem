using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.Project.Queries.GetById;

namespace PmsAPI.Controllers.Project;

[ApiController]
[Route("projects")]
[ApiExplorerSettings(GroupName = "projects")]
public class GetByIdProjectController : ControllerBase
{
    private readonly IProjectGetByIdQueryHandler _queryHandler;

    public GetByIdProjectController(IProjectGetByIdQueryHandler queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var project = await _queryHandler.Handle(new ProjectGetByIdQuery(id));

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}