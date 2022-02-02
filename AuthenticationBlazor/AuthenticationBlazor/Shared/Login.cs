
namespace AuthenticationBlazor.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Имя пользователя не должно быть пустым")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Пароль не должен быть пустым")]
        public string Password { get; set; }
    }
}
