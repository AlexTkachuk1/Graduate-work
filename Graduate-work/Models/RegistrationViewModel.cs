using Graduate_work.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [MinLength(2, ErrorMessage ="Слишком короткий никнейм")]
        [StringLength(maximumLength:10,ErrorMessage ="Указанный ник длиннее 10 символов, сделайте его короче")]
        public string Login { get; set; }

        [MinLength(6, ErrorMessage = "Слишком короткий")]
        [StringLength(maximumLength: 10, ErrorMessage = "Указанный пароль длиннее 10 символов, сделайте его короче")]
        [Required(ErrorMessage = "Не указан пароль пользователя")]
        public string Password { get; set; }

        [MinLength(6, ErrorMessage = "Слишком короткий")]
        [StringLength(maximumLength: 10, ErrorMessage = "Указанный пароль длиннее 10 символов, сделайте его короче")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Продублируйте свой пароль")]
        public string PasswordCopy { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public string DateOfBirth { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}
