
namespace AuthenticationBlazor.Shared
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Имя пользователя не должно быть пустым")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = "Имя пользователя должно содержать от 6 до 20 символов")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Пароль не должен быть пустым")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Пароль должен содержать от 8 до 15 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
