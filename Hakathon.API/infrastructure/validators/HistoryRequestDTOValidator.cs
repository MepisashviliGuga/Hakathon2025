using FluentValidation;
using Hakathon.API.infrastructure.PresentationDTOs;

namespace Hakathon.API.infrastructure.validators
{
    public class HistoryRequestDTOValidator : AbstractValidator<HistoryRequestDTO>
    {
        public HistoryRequestDTOValidator()
        {
            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("CarId must be greater than 0.");

            RuleFor(x => x.CardId)
                .GreaterThan(0).WithMessage("CardId must be greater than 0.");
        }
    }
}
