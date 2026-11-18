using FluentValidation;

namespace KooliProjekt.Application.Features.Bookings
{
    public class ListBookingQueryValidator : AbstractValidator<ListBookingQuery>
    {
        public ListBookingQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page must be greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize must be greater than or equal to 1.");
        }
    }
}
