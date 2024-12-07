using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RoleManagementController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleManagementController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet("roles")]
    public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
    {
        var roles = _roleManager.Roles;
        return Ok(roles);
    }
}