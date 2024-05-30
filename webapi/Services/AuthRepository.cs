

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webapi.Model;

namespace webapi.Services
{

    public class AuthRepository : IAuthRepository
    {


        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //IConfiguration Represents a set of key/value application configuration properties.
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext context;
        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext _context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            context = _context;

        }

        public async Task<(int, string)> Registeration(RegistrationModel model, string role)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return (0, "Email already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Name = model.Name
            };

            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
            {
                return (0, "User creation failed! Please check user details and try again.");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            if (await roleManager.RoleExistsAsync(UserRoles.User))
            {
                await userManager.AddToRoleAsync(user, role);
            }

            return (1, "User created successfully!");
        }
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<(int, string)> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return (0, "Invalid username");
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password");

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.Email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string token = GenerateToken(authClaims);
            return (1, token);
        }
    }


   

}

