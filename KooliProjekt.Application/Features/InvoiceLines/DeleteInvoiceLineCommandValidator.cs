using FluentValidation;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class DeleteInvoiceLineCommandValidator : AbstractValidator<DeleteInvoiceLineCommand>
    {
        public DeleteInvoiceLineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
