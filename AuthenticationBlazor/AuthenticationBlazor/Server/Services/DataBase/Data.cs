using System.Security.Cryptography;

namespace AuthenticationBlazor.Server.Services.DataBase
{
    public class Data : IData
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Product> Products { get; set; } = new List<Product> {
            new Product() {Name = "Iphone", Description = "v.10, blue", Price = 80000.00m, PurchasePrice = 40000.00m },
            new Product() {Name = "Iphone", Description = "v.11, purpule", Price = 95000.00m, PurchasePrice = 50000.00m },
            new Product() {Name = "Iphone", Description = "v.7, blue", Price = 45000.00m, PurchasePrice = 25000.00m },
            new Product() {Name = "Sumsung", Description = "v.Galaxy fold 2, gray", Price = 110000.00m, PurchasePrice = 66000.00m },
            new Product() {Name = "ZTE", Description = "v.Blade 20, red", Price = 12000.00m, PurchasePrice = 5000.00m },
            new Product() {Name = "ZTE", Description = "v.Blade 10 x, black", Price = 11000.00m, PurchasePrice = 4000.00m }
        };
        public Data()
        {
            CreatePasswordHash("password111", out byte[] passwordHash1, out byte[] passwordSalt1);
            Users.Add( new User() { UserName = "MaximDirector", Role = "Director", PasswordHash = passwordHash1, PasswordSalt = passwordSalt1 });
            CreatePasswordHash("password222", out byte[] passwordHash2, out byte[] passwordSalt2);
            Users.Add(new User() { UserName = "MaximAdmin", Role = "Admin", PasswordHash = passwordHash2, PasswordSalt = passwordSalt2 });
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
