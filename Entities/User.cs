using Microsoft.AspNetCore.Identity;
namespace forge_energy.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
