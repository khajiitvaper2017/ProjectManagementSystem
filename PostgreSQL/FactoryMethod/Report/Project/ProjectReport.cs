using PostgreSQL.Data.Entity;
using PostgreSQL.FactoryMethod.Report.Project.Parts;

namespace PostgreSQL.FactoryMethod.Report.Project;

public sealed class ProjectReport : Base.Report
{
    private readonly ProjectEntity _projectEntity;

    public ProjectReport(ProjectEntity projectEntity)
    {
        _projectEntity = projectEntity;
    }
    public override void CreateReport()
    {
        ReportParts.Add(new ProjectReportPart(_projectEntity));
        ReportParts.Add(new TasksReportPart(_projectEntity.Tasks));
    }
}