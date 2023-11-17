using System.Text;

namespace PostgreSQL.Report.Base;

public abstract class Report
{
    public List<IReportPart> ReportParts { get; set; } = new List<IReportPart>();
    public abstract void CreateReport();

    public string GetString()
    {
        var sb = new StringBuilder();
        foreach (var reportPart in ReportParts)
        {
            sb.Append(reportPart.GetString());
        }

        return sb.ToString();
    }
}