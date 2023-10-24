using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostgreSQL.CQRS.Core;

namespace PostgreSQL.CQRS.User.Remove
{
    public interface IRemoveUserCommand : INoResponseAsyncCommand<Guid>
    {
    }
}
