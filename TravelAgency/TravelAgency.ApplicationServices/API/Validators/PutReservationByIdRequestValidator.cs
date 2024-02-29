using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.ApplicationServices.API.Validators
{
    public class PutReservationByIdRequestValidator : AbstractValidator<PutReservationByIdRequest>
    {
        public PutReservationByIdRequestValidator()
        {
            this.RuleFor(x => x.PricePaid).GreaterThan(0)
                .WithMessage("WRONG_RANGE");
            this.RuleFor(x => x.AdultsNumber).GreaterThan(0)
                .WithMessage("WRONG_RANGE");
            this.RuleFor(x => x.KidsNumber).GreaterThan(0)
                .WithMessage("WRONG_RANGE");


        }
    }
}
