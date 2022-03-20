using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class ChangeRoleViewModel
    {
        [Required(ErrorMessage = "Не указан Login пользователя")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Выберите новую роль")]
        public string Role { get; set; }

    }
}
