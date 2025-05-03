using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoKala.CoreLayer.Dtos;
using TechnoKala.DaytaLayer.Entities;

namespace TechnoKala.CoreLayer.Servises.Users
{
   public interface IUserService 
    {

        OperationResult RegisterUser(UserRegisterDtos registerDtos);
        UserDto LoginUser(LoginDtos loginDtos);

  

    }
}
