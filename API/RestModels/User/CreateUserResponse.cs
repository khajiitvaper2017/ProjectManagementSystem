namespace API.RestModels.User;

public sealed record CreateUserResponse
{
    public string Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }

    public string Phone { get; }

    public CreateUserResponse(string id, string firstName, string lastName, string email, string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}