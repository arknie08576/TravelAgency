using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ApplicationServices.API.Domain;

namespace TravelAgency.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            this.RuleFor(x => x.Name).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Surname).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Login).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Password).MaximumLength(100).WithMessage("WRONG_LENGHT");
            this.RuleFor(x => x.Email).MaximumLength(100).WithMessage("WRONG_LENGHT");
        }
    }
}
