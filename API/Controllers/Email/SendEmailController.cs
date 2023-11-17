using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Data.Entity;
using PostgreSQL.Data.Repositories;
using PostgreSQL.Data.UnitOfWork;
using PostgreSQL.Mediator;

namespace PmsAPI.Controllers.Email;

[ApiController]
[Route("emails")]
[ApiExplorerSettings(GroupName = "emails")]

public class SendEmailController : ControllerBase
{
    private readonly IEmailMediator _emailMediator;
    private readonly IUnitOfWork _unitOfWork;

    public SendEmailController(IEmailMediator emailMediator, IUnitOfWork unitOfWork)
    {
        _emailMediator = emailMediator;
        _unitOfWork = unitOfWork;
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

    [HttpPost]
    [Route("addUsersToReceivers")]
    public IActionResult AddUsersToReceivers()
    {
        try
        {
            var users = (_unitOfWork.Repository<UserEntity>() as GenericRepository<UserEntity>).GetAll();

            foreach (var user in users)
            {
                _emailMediator.AddReceiver(user.Email);
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}