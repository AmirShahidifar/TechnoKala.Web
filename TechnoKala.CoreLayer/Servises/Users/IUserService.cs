using TechnoKala.CoreLayer.Dtos;

namespace TechnoKala.CoreLayer.Servises.Users
{
    public interface IUserService
    {

        OperationResult RegisterUser(UserRegisterDtos registerDtos);
        UserDto LoginUser(LoginDtos loginDtos);



    }
}
