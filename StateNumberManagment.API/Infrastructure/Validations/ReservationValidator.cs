using FluentValidation;
using StateNumberManagement.Application.StateNumberReservations.Request;
using System.Text.RegularExpressions;

namespace StateNumberManagment.API.Infrastructure.Validations
{
    public class ReservationValidator : AbstractValidator<StateNumberReservationRequestModel>
    {
        public ReservationValidator()
        {
            Regex rg = new Regex("[A-Z]{2}[0-9]{3}[A-Z]{2}");

            RuleFor(x => x.Number).NotEmpty().Length(7).Must(x => rg.IsMatch(x));

            RuleFor(x => x.Deadline).Must(x => x > DateTime.Now);
        }
    }
}
