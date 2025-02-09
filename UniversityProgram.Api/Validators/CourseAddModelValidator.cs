using FluentValidation;
using FluentValidation.AspNetCore;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Validators
{
    public class CourseAddModelValidator: AbstractValidator<CourseAddModel>
    {
        public CourseAddModelValidator()
        {
            RuleFor(e => e.Name)
                 .NotNull().WithMessage("Անունը null չի կարող լինել");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("Պարտադիր է")
                .GreaterThanOrEqualTo(1000).WithMessage("1000-ից պակաս լինել չի կարող")
                .LessThanOrEqualTo(2000).WithMessage("2000-ից ավել լինել չի կարող");
        }
    }
}
