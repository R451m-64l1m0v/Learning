using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RegisterToDoc.Models;

namespace RegisterToDoc.Validators
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            //todo: impl
            RuleFor(x => x.Age).InclusiveBetween(25,80);
            //RuleFor(x => x.Name).Length(0, 10);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
