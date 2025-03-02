using Application.Users.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users.Queries.GetUser;
public class GetUserQuery : IRequest<UserResponseModel>
{
    public Guid Id { get; set; }
}
public class GetUserQueryHandler(ApplicationDbContext context) : IRequestHandler<GetUserQuery, UserResponseModel>
{
    public async Task<UserResponseModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users.Select(u => new UserResponseModel
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            UserName = u.Name,
            UserProfile =  new UserProfileRequestModel
            {
                Address = u.UserProfile.Address,
                PhoneNumber = u.UserProfile.PhoneNumber
            }
        }).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) ?? throw new KeyNotFoundException($"User with Id {request.Id} not found.");

        return user;
    }
}