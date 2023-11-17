using System.Text;
using PostgreSQL.Data.Entity;
using PostgreSQL.Report.Base;

namespace PostgreSQL.Report.Project.Parts;

public class TasksReportPart : IReportPart
{
    private readonly ICollection<TaskEntity> _projectEntityTasks;
    public TasksReportPart(ICollection<TaskEntity> projectEntityTasks)
    {
        _projectEntityTasks = projectEntityTasks;
    }

    public string GetString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("Tasks:");
        foreach (var taskEntity in _projectEntityTasks)
        {
            stringBuilder.AppendLine($"Task: {taskEntity.Name}");
            stringBuilder.AppendLine($"Description: {taskEntity.Description}");
            stringBuilder.AppendLine($"Start date: {taskEntity.StartDate}");
            stringBuilder.AppendLine($"End date: {taskEntity.EndDate}");
            stringBuilder.AppendLine($"Status: {taskEntity.Status}");

            stringBuilder.AppendLine($"People assigned on task: {taskEntity.Assignments.Count}");
            foreach (var assignmentEntity in taskEntity.Assignments)
            {
                if (assignmentEntity.User is null)
                {
                    continue;
                }
                stringBuilder.AppendLine($"{assignmentEntity.User.GetFullName()} assigned on {assignmentEntity.Date}");
            }
            stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }
}