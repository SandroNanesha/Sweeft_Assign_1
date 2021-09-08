using DomainLayer.Models;
using FluentValidation;
using FluentValidation.Results;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.FluentValidators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleSet("idChecker", () =>
            {
                RuleFor(clt => clt.ID).Cascade(CascadeMode.StopOnFirstFailure)
                            .NotNull().WithMessage("{PropertyName} is null")
                            .NotEmpty().WithMessage("{PropertyName} field is empty")
                            .Length(11).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                            .Must(SyntaxChecker.IsDigitsOnly).WithMessage("{PropertyName} contains Invalid characters");
            });

            RuleFor(clt => clt.Tel).Cascade(CascadeMode.StopOnFirstFailure)
                                        .NotNull().WithMessage("{PropertyName} is null")
                                        .NotEmpty().WithMessage("{PropertyName} field is empty")
                                        .Length(9).WithMessage("Length of {TotalLength} of {PropertyName} Invalid")
                                        .Must(SyntaxChecker.IsDigitsOnly).WithMessage("{PropertyName} contains Invalid characters");

        }
    }
}
