using PostgreSQL.CQRS.Core.Command;
using PostgreSQL.Data.Dtos;

namespace PostgreSQL.CQRS.User.Commands.Create;

public sealed record UserCreateCommand : ICommand
{
    public UserInfoDto UserInfo { get; init; }

    public UserCreateCommand(string email, string phone, string firstName, string lastName)
    {
        UserInfo = new UserInfoDto
        {
            Email = email,
            Phone = phone,
            FirstName = firstName,
            LastName = lastName
        };
    }

    public UserCreateCommand(UserInfoDto userInfo)
    {
        UserInfo = userInfo;
    }
}