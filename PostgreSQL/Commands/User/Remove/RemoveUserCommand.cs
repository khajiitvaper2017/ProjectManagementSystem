﻿using PostgreSQL.Data;

namespace PostgreSQL.Commands.User.Remove;

public sealed class RemoveUserCommand : IRemoveUserCommand
{
    private readonly ProjectManagementDbContext _context;
    public RemoveUserCommand(ProjectManagementDbContext context)
    {
        _context = context;
    }
    public async System.Threading.Tasks.Task ExecuteAsync(Guid data)
    {
        var user = _context.Users.FindAsync(data);

        if (user.IsCompletedSuccessfully)
        {
            _context.Users.Remove(user.Result);
            await _context.SaveChangesAsync();
        }
    }
}