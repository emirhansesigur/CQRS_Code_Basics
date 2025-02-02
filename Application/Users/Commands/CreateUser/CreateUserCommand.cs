using Application.Users.Models;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Users.Commands.CreateUser;
public class CreateUserCommand : UserRequestModel, IRequest<User>
{
}

public class CreateUserCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateUserCommand, User>
{
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            UserName = request.UserName,
            Name = request.Name,
            Surname = request.Surname,
        };

        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
