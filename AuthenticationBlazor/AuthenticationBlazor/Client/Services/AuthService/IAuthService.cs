using AuthenticationBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationBlazor.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> Login(UserLogin request);
        Task<bool> Register(UserRegister request);
        void SetToken(string token);
        Task<string> GetToken();
        string ErrorMessage { get; set; }
    }
}
