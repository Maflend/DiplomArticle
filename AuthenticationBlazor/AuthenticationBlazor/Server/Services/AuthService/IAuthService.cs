

namespace AuthenticationBlazor.Server.Services.AuthService
{ 
    public interface IAuthService
    {
        Task<string> Login(UserLogin request);
        Task<User> Register(UserRegister request);
    }
}
