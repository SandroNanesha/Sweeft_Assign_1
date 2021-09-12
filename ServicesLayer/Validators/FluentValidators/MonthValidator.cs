using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.FluentValidators
{
    public class MonthValidator
    {
        public bool IsValidMonth(int month)
        {
            return month > 0 && month < 13;
        }
    }
}
