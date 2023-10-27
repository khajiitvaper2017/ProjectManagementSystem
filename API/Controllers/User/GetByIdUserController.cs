using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.User.Queries.GetById;

namespace PmsAPI.Controllers.User
{
    [ApiController]
    [Route("users")]
    [ApiExplorerSettings(GroupName = "users")]
    public class GetByIdUserController : ControllerBase
    {
        private readonly IUserGetByIdQueryHandler _queryHandler;

        public GetByIdUserController(IUserGetByIdQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var project = await _queryHandler.Handle(new UserGetByIdQuery(id));

                if (project is null)
                {
                    return NotFound();
                }

                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
