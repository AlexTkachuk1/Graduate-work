using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Graduate_work.Models.CastomValidationAttribute
{
    public class PhoneAttribut : ValidationAttribute
    {
        const string strPattern = @"^\s*\+?375((33\d{7})|(29\d{7})|(44\d{7}|)|(25\d{7}))\s*$";

        public PhoneAttribut()
        { 
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Неподходящий формат ввода {name}"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (!(value is string))
            {
                return false;
            }

            return Regex.IsMatch(value.ToString(), strPattern);
        }
    }
}
