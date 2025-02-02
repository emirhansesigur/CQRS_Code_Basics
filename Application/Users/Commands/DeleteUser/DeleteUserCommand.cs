using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Commands.DeleteUser;
public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteUserCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
           ?? throw new KeyNotFoundException($"User with Id {request.Id} not found.");

        context.Users.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}