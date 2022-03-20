using Graduate_work.Models.CastomValidationAttribute;
using System;
using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models
{
    public class AddDataViewModel
    {
        [StringLength(120, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(120, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(2048, MinimumLength = 3)]
        public string AvatarUrl { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string homeСountry { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string homeСity { get; set; }

        [Phone(ErrorMessage ="Неверный формат данных")]
        public string Tel { get; set; }

        [StringLength(200, MinimumLength = 5)]
        public string Email { get; set; }
    }
}
