using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfAppAccaunting.valid
{
    class Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (((string)value).Length == 0)
                return new ValidationResult(false, "Поле не должно быть пустым.");

            foreach (char s in (string)value)

                if (!(char.IsDigit(s) || char.IsPunctuation(s)))
                    return new ValidationResult(false, "Запрещенные символы.");

            return new ValidationResult(true, null);
        }
    }
}
