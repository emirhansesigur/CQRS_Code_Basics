using Application.Users.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Queries.GetUsers;
public class GetUsersQuery : IRequest<List<UserResponseModel>>
{
}

public class GetUsersQueryHandler(ApplicationDbContext context) : IRequestHandler<GetUsersQuery, List<UserResponseModel>>
{
    public async Task<List<UserResponseModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await context.Users.Select(u => new UserResponseModel
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            UserName = u.Name
        }).ToListAsync(cancellationToken);

        return users;
    }
}