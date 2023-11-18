namespace PostgreSQL.Data.Entity;

public interface IEmailUser
{
    string? Email { get; set; }

    public Task ReceieveEmailAsync(string subject, string message, string sender);
}
