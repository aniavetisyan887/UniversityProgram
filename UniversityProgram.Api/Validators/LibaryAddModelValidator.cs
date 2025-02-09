using FluentValidation;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Validators
{
    public class LibaryAddModelValidator: AbstractValidator<LibraryAddModel>
    {
        public LibaryAddModelValidator()
        {
            RuleFor(e=>e.Id)
                .GreaterThan(0).WithMessage("Id-ն պետք է 0-ից մեծ լինի");

            RuleFor(e => e.Name)
                .NotNull().WithMessage("Անունը պարտադիր է");
        }
    }
}
