using Application.Users.Models;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Commands.UpdateUser;
public class UpdateUserCommand : UserRequestModel, IRequest<User>
{
    public Guid Id { get; set; }
}

public class UpdateUserCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateUserCommand, User>
{
    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"User with Id {request.Id} not found.");
        }

        entity.UserName = request.UserName;
        entity.Name = request.Name;
        entity.Surname = request.Surname;

        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}