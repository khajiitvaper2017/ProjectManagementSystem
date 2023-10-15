using System.ComponentModel.DataAnnotations;
using API.RestModels.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PostgreSQL.CQRS.User.Commands.Create;
using PostgreSQL.CQRS.User.Queries.FindUser;
using PostgreSQL.Dtos;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace API.Controllers;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "users")]
public sealed class CreateUserController : ControllerBase
{
    private readonly IValidator<CreateUserRequest> _validator;
    private readonly ICreateUserCommandHandler _createUserCommandHandler;
    private readonly IFindUserQueryHandler _findUserQueryHandler;
    private readonly ILogger<CreateUserController> _logger;

    public CreateUserController(
        IValidator<CreateUserRequest> validator,
        ICreateUserCommandHandler createUserCommandHandler,
        IFindUserQueryHandler findUserQueryHandler,
        ILogger<CreateUserController> logger)
    {
        _validator = validator;
        _createUserCommandHandler = createUserCommandHandler;
        _findUserQueryHandler = findUserQueryHandler;
        _logger = logger;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserRequest request)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors
                .Select(e => new { e.PropertyName, e.ErrorMessage }));
        }

        string passwordHash = ""; // todo: process password hashing

        try
        {
            CreateUserCommand createUserCommand = new CreateUserCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                passwordHash);

            await _createUserCommandHandler.Handle(createUserCommand);

            UserInfoDto? userInfo = await _findUserQueryHandler.Handle(new FindUserQuery(request.Email));

            if (userInfo != null)
            {
                CreateUserResponse response = new CreateUserResponse(
                    userInfo.Id,
                    userInfo.FirstName,
                    userInfo.LastName,
                    userInfo.Email, 
                    userInfo.Phone);

                return Ok(response);
            }

            _logger.LogError($"Could not find user after creations");

            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occured during the user creation process");

            return Problem("Something went wrong");
        }
    }
}