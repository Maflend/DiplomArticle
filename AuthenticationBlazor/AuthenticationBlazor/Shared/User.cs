
namespace AuthenticationBlazor.Shared
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
