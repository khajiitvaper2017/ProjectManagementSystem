using System.Text;
using PostgreSQL.Data.Entity;
using PostgreSQL.FactoryMethod.Report.Base;

namespace PostgreSQL.FactoryMethod.Report.Project.Parts;

public class ProjectReportPart : IReportPart
{
    private readonly ProjectEntity _projectEntity;
    public ProjectReportPart(ProjectEntity projectEntity)
    {
        _projectEntity = projectEntity;
    }

    public string GetString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Project: {_projectEntity.Name}");
        stringBuilder.AppendLine($"Description: {_projectEntity.Description}");
        stringBuilder.AppendLine($"Start date: {_projectEntity.StartDate}");
        stringBuilder.AppendLine($"End date: {_projectEntity.EndDate}");

        return stringBuilder.ToString();
    }
}