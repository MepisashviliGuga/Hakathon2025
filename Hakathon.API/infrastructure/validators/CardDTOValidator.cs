using FluentValidation;
using Hakathon.API.infrastructure.PresentationDTOs;

namespace Hakathon.API.infrastructure.validators
{
    public class CardDTOValidator : AbstractValidator<CardDTO>
    {
        public CardDTOValidator()
        {
            RuleFor(x => x.CardNumber)
                .NotEmpty().WithMessage("Card number is required.")
                .Matches(@"^\d{16}$").WithMessage("Card number must be exactly 16 digits.");

            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance cannot be negative.");
        }
    }
}
