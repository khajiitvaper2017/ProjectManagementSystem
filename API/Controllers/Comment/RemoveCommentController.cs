﻿using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Comment.Remove;

namespace PmsAPI.Controllers.Comment;

[ApiController]
[Route("comments")]
[ApiExplorerSettings(GroupName = "comments")]

public class RemoveCommentController : ControllerBase
{
    private readonly IRemoveCommentCommand _command;

    public RemoveCommentController(IRemoveCommentCommand command)
    {
        _command = command;
    }

    [HttpPost]
    [Route("remove")]
    public async Task<IActionResult> RemoveComment([FromBody] Guid id)
    {
        try
        {
            await _command.ExecuteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}