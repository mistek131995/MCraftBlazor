using MCraftBlazor.Helpers.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MCraftBlazor.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Логин не может быть пустым.")]
        [MinLength(5, ErrorMessage = "Минимальная длина логина 5 символов.")]
        [MaxLength(12, ErrorMessage = "Максимальная длина логина 12 символов.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не может быть пустым.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Адрес электронной почты не может быть пустым.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты.")]
        public string Email { get; set; }
        [Required]
        [BoolEquals(true, ErrorMessage = "Вы должны принять правла для регистрации.")]
        public bool RuleAccept { get; set; }
    }
}
