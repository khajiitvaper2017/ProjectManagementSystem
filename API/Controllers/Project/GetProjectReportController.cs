using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.UnitOfWork;
using PostgreSQL.Report.Project;

namespace PmsAPI.Controllers.Project;

[ApiController]
[Route("projects")]
[ApiExplorerSettings(GroupName = "projects")]

public class GetProjectReportController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectReportController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("report/{id}")]
    public async Task<IActionResult> GetProjectReport(Guid id)
    {
        try
        {
            var project = (_unitOfWork.Repository<ProjectEntity>() as GenericRepository<ProjectEntity>)?.GetById(id);

            if (project is null)
            {
                return NotFound();
            }

            var report = new ProjectReport(project);

            report.CreateReport();

            return Ok(report.GetString());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}