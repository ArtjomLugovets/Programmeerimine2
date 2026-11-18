using FluentValidation;

namespace KooliProjekt.Application.Features.Invoices
{
    public class GetInvoiceQueryValidator : AbstractValidator<GetInvoiceQuery>
    {
        public GetInvoiceQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
