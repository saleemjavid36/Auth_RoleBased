using Custom_Jwt_Token_Example.Helper;
using Custom_Jwt_Token_Example.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Custom_Jwt_Token_Example.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<User> _users = new List<User> {
            new User {
                Id = 1, FirstName = "mytest", LastName = "User", Username = "mytestuser",Role= new List<Role>{Role.Admin} , Password = "test123"
            }
        };
        private readonly AppSettings _appSettings;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.UserName && x.Password == model.Password);
            if (user == null) return null;
            var token = generateToken(user);
            return new AuthenticateResponse() {Token= token};
            
        }

        private string generateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credetial = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>(){
                    new Claim("Id",Convert.ToString(user.Id)),
                    new Claim(JwtRegisteredClaimNames.Sub, "Test"),
                    new Claim(JwtRegisteredClaimNames.Email, "test@gmail.com"),
                    //new Claim("Role", Convert.ToString(user.Role)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            

            foreach (var role in user.Role) {

                claims.Add(new Claim("Role", Convert.ToString(role)));
            }

            var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer, claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: credetial);
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
