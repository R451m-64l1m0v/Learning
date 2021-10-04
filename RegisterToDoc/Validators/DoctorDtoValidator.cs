using FluentValidation;
using RegisterToDoc.Models;

namespace RegisterToDoc.Validators
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            RuleFor(x => x.Age).InclusiveBetween(25,80);
            RuleFor(x => x.Experience).GreaterThan(0);
            RuleFor(x => x.Name).Length(2, 30);
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Education).NotEmpty();
            RuleFor(x => x.Specialization).NotEmpty();
        }
    }


}
