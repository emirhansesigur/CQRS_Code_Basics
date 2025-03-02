using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

}
