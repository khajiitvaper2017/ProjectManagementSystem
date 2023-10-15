namespace PostgreSQL.Data.Entity;

public partial class Comment
{
    public string Id { get; set; }

    public string? Text { get; set; }

    public DateTime? Date { get; set; }

    public int? TaskId { get; set; }

    public int? UserId { get; set; }

    public virtual Task? Task { get; set; }

    public virtual User? User { get; set; }
}
