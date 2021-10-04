using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RegisterToDoc.Models;

namespace RegisterToDoc.Validators
{
    public class WorkGraphicValidator : AbstractValidator<WorkGraphicDto>
    {
        public WorkGraphicValidator()
        {
            RuleFor(x => x.StartHour).InclusiveBetween(1,24);
            RuleFor(x => x.EndHour).InclusiveBetween(1,24);
            RuleFor(x => x.DayNumber).InclusiveBetween(1, 31);
        }
    }
}
