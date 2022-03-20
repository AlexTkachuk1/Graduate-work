using System;
using System.ComponentModel.DataAnnotations;

namespace Graduate_work.Models.CastomValidationAttribute
{
    /// <summary>
    /// Необходимо ввести наиболее раннюю дату рождения в формате "01/01/1920 00:00:00"
    /// </summary>
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public DateTime minDateOfBirth { get; set; }

        public DateTime maxDateOfBirth { get; set; }

        public DateOfBirthAttribute(string minDateOfBirth)
        {
            this.minDateOfBirth = DateTime.Parse(minDateOfBirth);
            this.maxDateOfBirth = DateTime.Now;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Значение {name} должно быть больше либо равно {minDateOfBirth}"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (!(value is DateTime))
            {
                return false;
            }

            return (DateTime)value > minDateOfBirth && (DateTime)value < maxDateOfBirth;
        }
    }
}
