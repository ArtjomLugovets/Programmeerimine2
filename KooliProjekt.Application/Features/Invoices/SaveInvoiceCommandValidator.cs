using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Invoices
{
    public class SaveInvoiceCommandValidator : AbstractValidator<SaveInvoiceCommand>
    {
        public SaveInvoiceCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Invoices.Any(invoice => invoice.Id == id))
                .WithMessage("The specified invoice does not exist.");

            RuleFor(x => x.InvoiceDate)
                .NotEmpty().WithMessage("InvoiceDate is required.");

            RuleFor(x => x.Duedate)
                .NotEmpty().WithMessage("Duedate is required.")
                .Must((command, dueDate) => dueDate >= command.InvoiceDate)
                .WithMessage("Duedate must be on or after InvoiceDate.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.")
                .Must(id => dbContext.Users.Any(user => user.Id == id))
                .WithMessage("The specified user does not exist.");
        }
    }
}
