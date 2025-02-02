using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class UsersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserCommand command)
    {
        var data = await Mediator.Send(command);
        return Ok(data);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(UpdateUserCommand command)
    {
        var data = await Mediator.Send(command);
        return Ok(data);
    }

    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        var data = await Mediator.Send(new GetUsersQuery());
        return Ok(data);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        await Mediator.Send(new DeleteUserCommand { Id = id });
        return StatusCode(200);
    }
}
