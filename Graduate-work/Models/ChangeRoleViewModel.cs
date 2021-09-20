using Graduate_work.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class ChangeRoleViewModel
    {
        [Required(ErrorMessage = "Не указан Id пользователя")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Выберите новую роль")]
        public string Role { get; set; }

    }
}
