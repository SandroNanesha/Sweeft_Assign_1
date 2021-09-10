using DomainLayer.DTOs;
using DomainLayer.Models;
using FluentValidation;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.FluentValidators
{

    public class CarValidator : AbstractValidator<CarDTO>
    {

        public CarValidator()
        {
            RuleSet("requestChecker", () =>
            {
                RuleFor(c => c.ownerID).Cascade(CascadeMode.StopOnFirstFailure)
                         .NotNull().WithMessage("{PropertyName} is null")
                         .NotEmpty().WithMessage("{PropertyName} field is empty")
                         .Length(11).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                         .Must(SyntaxChecker.IsDigitsOnly).WithMessage("{PropertyName} contains Invalid characters");

                RuleFor(c => c.vinCode).Cascade(CascadeMode.StopOnFirstFailure)
                         .NotNull().WithMessage("{PropertyName} is null")
                         .NotEmpty().WithMessage("{PropertyName} field is empty");


            });

                

            RuleFor(c => c.Brand).Cascade(CascadeMode.StopOnFirstFailure)
                         .NotNull().WithMessage("{PropertyName} is null")
                         .NotEmpty().WithMessage("{PropertyName} field is empty");

            RuleFor(c => c.Model).Cascade(CascadeMode.StopOnFirstFailure)
                         .NotNull().WithMessage("{PropertyName} is null")
                         .NotEmpty().WithMessage("{PropertyName} field is empty");

            RuleFor(c => c.SerialNum).Cascade(CascadeMode.StopOnFirstFailure)
                         .NotNull().WithMessage("{PropertyName} is null")
                         .NotEmpty().WithMessage("{PropertyName} field is empty");

            RuleFor(c => c.ReleaseYear).NotNull().WithMessage("{PropertyName} is null");


            RuleFor(c => c.Price).NotNull().WithMessage("{PropertyName} is null");

            RuleFor(c => c.StartDate).NotNull().WithMessage("{PropertyName} is null");

            RuleFor(c => c.EndDate).NotNull().WithMessage("{PropertyName} is null");


        }
    }
}
