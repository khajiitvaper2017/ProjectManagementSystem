using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Comment.Create;
using PostgreSQL.Data.Dtos;

namespace PmsAPI.Controllers.Comment;

[ApiController]
[Route("comments")]
[ApiExplorerSettings(GroupName = "comments")]

public class CreateCommentController : ControllerBase
{
    private readonly ICreateCommentCommand _command;

    public CreateCommentController(ICreateCommentCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateComment([FromBody] CommentInfoDto dto)
    {
        try
        {
            await _command.ExecuteAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}