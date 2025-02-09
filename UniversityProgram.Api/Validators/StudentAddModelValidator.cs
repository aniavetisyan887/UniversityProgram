using FluentValidation;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Validators
{
    public class StudentAddModelValidator: AbstractValidator<Models.StudentAddModel>
    {
        public StudentAddModelValidator()
        {
            RuleFor(e => e.Name)
                .NotNull().WithMessage("Անունտ պարտադիր է")
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("email-ը պարտադիր է")
                .EmailAddress().WithMessage("Թերի գրված email")
                .MaximumLength(100);
        }
    }
}
