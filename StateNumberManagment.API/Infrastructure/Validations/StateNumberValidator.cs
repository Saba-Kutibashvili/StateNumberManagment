using FluentValidation;
using StateNumberManagement.Application.StateNumbers.Request;
using System.Text.RegularExpressions;

namespace StateNumberManagment.API.Infrastructure.Validations
{
    public class StateNumberValidator : AbstractValidator<StateNumberRequestModel>
    {
        public StateNumberValidator() 
        {
            Regex rg = new Regex("[A-Z]{2}[0-9]{3}[A-Z]{2}");

            RuleFor(x => x.Number).NotEmpty().Length(7).Must(x => rg.IsMatch(x));
        }
    }
}
