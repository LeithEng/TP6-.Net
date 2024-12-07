using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;

namespace WebApplication2.Services;
public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public IEnumerable<ApplicationUser> GetUsersList()
    {
        // Retourner la liste des utilisateurs
        return _userManager.Users;
    }
}