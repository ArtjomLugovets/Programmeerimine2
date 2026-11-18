using FluentValidation;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class GetInvoiceLineQueryValidator : AbstractValidator<GetInvoiceLineQuery>
    {
        public GetInvoiceLineQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
