namespace PostgreSQL.Data.Dtos
{
    public sealed record UserInfoDto
    {
        public string Id { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Phone { get; init; }

        public UserInfoDto(string id, string email, string firstName, string lastName, string phone)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
