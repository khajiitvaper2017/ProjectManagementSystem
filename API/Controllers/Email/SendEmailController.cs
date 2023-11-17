using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Commands.Comment.Create;
using PostgreSQL.Data.Dtos;
using PostgreSQL.Mediator;

namespace PmsAPI.Controllers.Email;

[ApiController]
[Route("emails")]
[ApiExplorerSettings(GroupName = "emails")]

public class SendEmailController : ControllerBase
{
    private readonly IEmailMediator _emailMediator;

    public SendEmailController(IEmailMediator emailMediator)
    {
        _emailMediator = emailMediator;
    }

    [HttpPost]
    [Route("sendToAll")]
    public async Task<IActionResult> SendToAll(string subject, string message)
    {
        try
        {
            await _emailMediator.SendEmailToAllAsync(subject, message);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> Send(string receiverEmail, string subject, string message)
    {
        try
        {
            await _emailMediator.SendEmailAsync(receiverEmail, subject, message);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("addReceiver")]
    public IActionResult AddReceiver(string email)
    {
        try
        {
            _emailMediator.AddReceiver(email);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}