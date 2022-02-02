using AuthenticationBlazor.Server.Services.DataBase;
using AuthenticationBlazor.Server.Services.JWTService;
using System.Security.Claims;

namespace AuthenticationBlazor.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IJWTService _jWTService;
        private readonly IData _data;

        public AuthService(IJWTService jWTService, IData data)
        {
            _jWTService = jWTService;
            _data = data;
        }
        public async Task<string> Login(UserLogin request)
        {
            var user =  _data.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (!_jWTService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Неверный пароль"); 
            }

            string token = _jWTService.CreateToken(user);
            return token;
        }

        public async Task<User> Register(UserRegister request)
        {
            if(!_data.Users.Any(u=>u.UserName == request.UserName))
            {
                _jWTService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = new User();
                user.Role = "Client";
                user.UserName = request.UserName;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _data.Users.Add(user);
                return user;
            }
            else
            {
                throw new Exception("Логин занят");
            }
            
        }
    }
}
