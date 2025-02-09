using FluentValidation;
using UniversityProgram.Api.Models;

namespace UniversityProgram.Api.Validators
{

    public class CpuAddModelValidator : AbstractValidator<CpuAddModel>
    {
        public CpuAddModelValidator()
        {
            RuleFor(e => e.Name).NotNull().Must(e =>
            {
                foreach (var a in e)
                {
                    if (char.IsSymbol(a))
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage("Սիմվոլներ չեն կարելի");

            RuleFor(e => e.Id).Must(e => e > 5).WithMessage("Id-ն պետք է զրոյից մեծ լինի");
        }
    }
    
}
