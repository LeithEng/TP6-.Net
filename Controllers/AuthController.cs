using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.JWTBearerConfig;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
public class AuthController : ControllerBase
 {
 private readonly JwtBearerTokenSettings jwtBearerTokenSettings;
 private readonly UserManager<ApplicationUser> userManager;
 public AuthController(IOptions<JwtBearerTokenSettings> jwtTokenOptions,
 UserManager<ApplicationUser> userManager)
 {
 this.jwtBearerTokenSettings = jwtTokenOptions.Value;
 this.userManager = userManager;
 }
 [HttpPost]
 [Route("register")]
 public async Task<IActionResult> Register([FromBody] RegisterCredentials
 userDetails)
 {
 if (!ModelState.IsValid || userDetails == null)
 {
 return new BadRequestObjectResult(new
 {
 Message = "User Registration Failed" });
 }
 var identityUser = new ApplicationUser()
 {
 UserName = userDetails.Username,
 Email = userDetails.Email,
 city =userDetails.City,
 };
 var result = await userManager.CreateAsync(identityUser, userDetails.Password);
 if (!result.Succeeded)
 {
 var dictionary = new ModelStateDictionary();
 foreach (IdentityError error in result.Errors)
 {
 dictionary.AddModelError(error.Code, error.Description);
 }
 return new BadRequestObjectResult(new
 {
 Message = "User Registration Failed", Errors = 
dictionary });
 }
 return Ok(new { Message = "User Reigstration Successful" });
 }
 [HttpPost]
 [Route("Login")]
 public async Task<IActionResult> Login([FromBody] LoginCredentials
 credentials)
 {
 ApplicationUser identityUser;
 if (!ModelState.IsValid
 || credentials == null
 || (identityUser = await ValidateUser(credentials)) == null)
 {
 return new BadRequestObjectResult(new
 {
 Message = "Login failed"
 });
 }
 var token = GenerateToken(identityUser);
 return Ok(new { Token = token, Message = "Success" });
 }
 [HttpPost]
 [Route("Logout")]
 public async Task<IActionResult> Logout()
 {
 // Well, What do you want to do here ?
 // Wait for token to get expired OR
 // Maintain token cache and invalidate the tokens after logout method
 return Ok(new { Token = "", Message = "Logged Out" });
 }
 private async Task<ApplicationUser> ValidateUser(LoginCredentials
 credentials)
 {
 var identityUser = await
 userManager.FindByNameAsync(credentials.Username);
 if (identityUser != null)
 {
 var result =
 
userManager.PasswordHasher.VerifyHashedPassword(identityUser,
 identityUser.PasswordHash, credentials.Password);
 return result == PasswordVerificationResult.Failed ? null :
 identityUser;
 }
 return null;
 }
 private object GenerateToken(IdentityUser identityUser)
 {
 var tokenHandler = new JwtSecurityTokenHandler();
 var key = 
Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);
 var tokenDescriptor = new SecurityTokenDescriptor
 {
 Subject = new ClaimsIdentity(new Claim[]
 {
 
 new Claim(ClaimTypes.Name, 
identityUser.UserName.ToString()),
 new Claim(ClaimTypes.Email, identityUser.Email)}),
 Expires 
=DateTime.UtcNow.AddSeconds(jwtBearerTokenSettings.ExpireTimeInSeconds),
 SigningCredentials = new SigningCredentials(new
 SymmetricSecurityKey(key), 
SecurityAlgorithms.HmacSha256Signature),
 Audience = jwtBearerTokenSettings.Audience,
 Issuer = jwtBearerTokenSettings.Issuer
 };
 var token = tokenHandler.CreateToken(tokenDescriptor);
 return tokenHandler.WriteToken(token);
 }
 }
 