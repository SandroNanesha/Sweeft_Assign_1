using DomainLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.FluentValidators
{
    public class DateValidator : AbstractValidator<DateDTO>
    {
        
        public DateValidator()
        {
            RuleSet("idChecker", () =>
            {
                RuleFor(dat => dat.StartDate).Cascade(CascadeMode.StopOnFirstFailure)
                                            .NotNull().WithMessage("{PropertyName} is null")
                                            .NotEmpty().WithMessage("{PropertyName} field is empty")
                                            .Length(10).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                                            .Must(IsValid).WithMessage("{PropertyName} contains Invalid characters");

                RuleFor(dat => dat.EndDate).Cascade(CascadeMode.StopOnFirstFailure)
                                            .NotNull().WithMessage("{PropertyName} is null")
                                            .NotEmpty().WithMessage("{PropertyName} field is empty")
                                            .Length(10).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                                            .Must(IsValid).WithMessage("{PropertyName} contains Invalid characters");

            });
        }


        
        private bool IsValid(String txtDate)
        {
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(txtDate.Trim());

            //Verify whether entered date is Valid date.
            DateTime dt;

            return DateTime.TryParseExact(txtDate, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            
        }
    }
}
