using System.ComponentModel.DataAnnotations;

namespace Custom_Jwt_Token_Example.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName 
        { 
            get; 
            set;
        }

        [Required]
        public string Password 
        { 
            get; 
            set; 
        }
    }
}
