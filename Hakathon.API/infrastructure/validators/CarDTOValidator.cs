using FluentValidation;
using Hakathon.API.infrastructure.PresentationDTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Hakathon.API.infrastructure.validators
{
    public class CarDTOValidator : AbstractValidator<CarDTO>
    {
        public CarDTOValidator()
        {
            RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Brand is required.");

            RuleFor(x => x.Serie)
                .NotEmpty().WithMessage("Serie is required.");


            RuleFor(x => x.CarIdentifier)
                .NotEmpty().WithMessage("Car identifier is required.")
                .Matches(@"^[A-Za-z]{2}\d{3}[A-Za-z]{2}$")
                .WithMessage("Car identifier must follow the format: 2 letters, 3 digits, 2 letters.");
        }
    }
}
