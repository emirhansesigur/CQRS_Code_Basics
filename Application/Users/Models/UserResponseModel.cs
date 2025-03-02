namespace Application.Users.Models;
public class UserResponseModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserProfileRequestModel UserProfile { get; set; }
}
