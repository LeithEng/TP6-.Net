using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;

namespace WebApplication2.Services;
public interface IUserService
{
    IEnumerable<ApplicationUser> GetUsersList();
}