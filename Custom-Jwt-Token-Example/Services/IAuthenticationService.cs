using Custom_Jwt_Token_Example.Models;

namespace Custom_Jwt_Token_Example.Services
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
