namespace WebApplication2.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser: IdentityUser
{
    public string city { get; set; }
}