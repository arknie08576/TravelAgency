using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.ApplicationServices.API.Validators
{
    public class AddOpinionRequestValidator : AbstractValidator<AddOpinionRequest>
    {
        public AddOpinionRequestValidator()
        {
            this.RuleFor(x=>x.Rating).InclusiveBetween(1, 6).WithMessage("WRONG_RANGE");

     
        }
    }
}
