using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [MinLength(2, ErrorMessage = "Слишком короткий никнейм")]
        [StringLength(maximumLength: 10, ErrorMessage = "Указанный ник длиннее 10 символов, сделайте его короче")]
        public string Login { get; set; }

        [MinLength(6, ErrorMessage = "Слишком короткий")]
        [StringLength(maximumLength: 10, ErrorMessage = "Указанный пароль длиннее 10 символов, сделайте его короче")]
        [Required(ErrorMessage = "Не указан пароль пользователя")]
        public string Password { get; set; }
    }
}
