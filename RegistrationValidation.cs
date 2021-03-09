using System.Linq;
using BankApp.Models;
using FluentValidation;
using FluentValidation.Results;

namespace BankApp
{
    public class RegistrationValidation : AbstractValidator<User>
    {
        public RegistrationValidation()
        {
            //Missing uniqueness checks?
            RuleFor(u => u.Username)
            .Cascade(CascadeMode.Stop)
            .Length(4, 20).WithMessage("Must be 4 - 20 characters");


            RuleFor(p => p.Password)
            .Length(8, 20).WithMessage("Must be 8 - 32 characters");

            RuleFor(fn => fn.FirstName)
            .MaximumLength(32).WithMessage("Must be no more than 32 characters");

            RuleFor(ln => ln.Lastname)
            .MaximumLength(32).WithMessage("Must be no more than 32 characters");
        }

        public bool CheckValidation(ValidationResult results)
        {
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    System.Console.WriteLine($"{failure.PropertyName}: {failure.ErrorMessage}, try again");
                }
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}