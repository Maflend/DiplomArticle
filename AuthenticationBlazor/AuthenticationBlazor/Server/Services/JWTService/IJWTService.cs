using System.Security.Claims;

namespace AuthenticationBlazor.Server.Services.JWTService
{
    public interface IJWTService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateToken(User user);
        ClaimsIdentity Claims { get; set; }
    }
}
