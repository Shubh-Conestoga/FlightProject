using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProjectByFinal_5
{
    class BookingValidator : ValidationRule
    {
        private string validationFor;

        public string ValidationFor { get => validationFor; set => validationFor = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (validationFor == "name")
            {
                string name = value.ToString();
                if (name.Length > 0)
                {
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "Please Enter Name");
                }
            }
            if (validationFor == "passport")
            {
                string passport = value.ToString();
                if (passport.Trim().Length != 6)
                {
                    return new ValidationResult(false, "Passport should have 6 letters");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            if (validationFor == "creditcard")
            {
                string creditcard = value.ToString();
                long cc;
                if (creditcard.Trim().Length != 16)
                {
                    return new ValidationResult(false, "Creditcard should have 16 digits!");
                }
                else if (!long.TryParse(creditcard.Trim(), out cc))
                {
                    return new ValidationResult(false,"Creditcard number must only contains 16 digits");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            if (validationFor == "age")
            {
                string age = value.ToString().Trim();
                int ageVal;
                long cc;
                if (age.Length == 0)
                {
                    return new ValidationResult(false, "Please Enter Your Age");
                }
                else if (!int.TryParse(age, out ageVal))
                {
                    return new ValidationResult(false, "Age must be an integer value");
                }
                else if (ageVal <= 0)
                { 
                    return new ValidationResult(false, "Age must be greater than zero!");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false,"Something went wrong");
        }
    }
}
