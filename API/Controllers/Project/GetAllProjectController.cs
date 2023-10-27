using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.Project.Queries.GetAll;
using PostgreSQL.Data.Entity;

namespace PmsAPI.Controllers.Project;

[ApiController]
[Route("projects")]
[ApiExplorerSettings(GroupName = "projects")]
public class GetAllProjectController : ControllerBase
{
    private readonly IProjectGetAllQueryHandler _queryHandler;

    public GetAllProjectController(IProjectGetAllQueryHandler queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectEntity>> GetAll()
    {
        var projects = await _queryHandler.Handle(new ProjectGetAllQuery());

        return projects;
    }
}