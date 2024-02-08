using Custom_Jwt_Token_Example.Models;

namespace Custom_Jwt_Token_Example.Services
{
    public interface IUserService
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}
