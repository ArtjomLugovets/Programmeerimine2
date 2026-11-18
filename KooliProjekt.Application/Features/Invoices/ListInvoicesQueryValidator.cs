using FluentValidation;

namespace KooliProjekt.Application.Features.Invoices
{
    public class ListInvoicesQueryValidator : AbstractValidator<ListInvoicesQuery>
    {
        public ListInvoicesQueryValidator()
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
