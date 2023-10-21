using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.Commands.Core;

namespace PostgreSQL.Commands.User.Remove
{
    public interface IRemoveUserCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
