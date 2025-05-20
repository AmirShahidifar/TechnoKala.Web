using TechnoKala.CoreLayer.Dtos;
using TechnoKala.DaytaLayer.Contex;


namespace TechnoKala.CoreLayer.Servises.Users
{

    public class UserService : IUserService
    {
        private readonly AppDbContex _contex;

        public UserService(AppDbContex contex)
        {
            _contex = contex;

        }
        public OperationResult RegisterUser(UserRegisterDtos registerDtos)
        {


            var isEmailExist = _contex.users.Any(e => e.email == registerDtos.email);
            var passwordconfirm = _contex.users.Any(p => p.password == registerDtos.confirmpasword);

            if (!passwordconfirm)
            {
                return OperationResult.Error("رمز عبور اشتباه است");
            }
            if (isEmailExist)
            {

                return OperationResult.Error("نام کاربری تکراری است");
            }
            else
            {

                _contex.users.Add(new DaytaLayer.Entities.Users()
                {
                    firstname = registerDtos.firstname,
                    lastname = registerDtos.lastname,
                    email = registerDtos.email,
                    created_at = DateTime.Now,
                    is_dleated = false,
                    dleated_at = DateTime.Now,
                    password = registerDtos.password


                });
                _contex.SaveChanges();
                return OperationResult.Success();
            }
        }

        public UserDto LoginUser(LoginDtos loginDtos)
        {
            var User = _contex.users.FirstOrDefault(u => u.email == loginDtos.email && u.password == loginDtos.password);

            if (User == null)
            {
                return null;
            }
            else
            {
                var userdto = new UserDto()
                {
                    firstname = User.firstname,
                    lastname = User.lastname,
                    email = User.email,

                };
                return userdto;
            }






        }




    }
}


