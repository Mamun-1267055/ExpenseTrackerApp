using System;
using System.ComponentModel.DataAnnotations;

namespace Work01.CustomValidation
{
    public class DateValidAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime todayDate = Convert.ToDateTime(value);
            return todayDate <= DateTime.Now;
        }


    }
}
