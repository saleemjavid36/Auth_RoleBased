using Custom_Jwt_Token_Example.Models;
using Custom_Jwt_Token_Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace Custom_Jwt_Token_Example.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService) { 
        this.authenticationService = authenticationService; 
        }
        [HttpPost]
        [Route("Login")]
        public AuthenticateResponse Login(AuthenticateRequest model)
        {
            return this.authenticationService.Authenticate(model);
            
        }
    }
}
