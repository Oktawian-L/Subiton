using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.Helpers
{
    public static class Extensions
    {
        public static int CalculateAge(this DateTime datetime)
        {
            var age = DateTime.Today.Year - datetime.Year;
            //if have birthdasys in current year
            if (datetime.AddYears(age) > DateTime.Today)
                age--;
            return age;
        }
    }
}
