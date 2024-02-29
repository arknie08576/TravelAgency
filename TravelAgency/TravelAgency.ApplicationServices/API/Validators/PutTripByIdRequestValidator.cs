using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.ApplicationServices.API.Validators
{
    public class PutTripByIdRequestValidator : AbstractValidator<PutTripByIdRequest>
    {
        public PutTripByIdRequestValidator()
        {
            this.RuleFor(x => x.HotelName).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Country).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.City).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Departure).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Food).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.RequiredDocuments).MaximumLength(100).WithMessage("WRONG_LENGHT");


        }
    }
}
