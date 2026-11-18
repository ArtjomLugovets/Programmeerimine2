using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.InvoiceLines
{
    public class SaveInvoiceLineCommandValidator : AbstractValidator<SaveInvoiceLineCommand>
    {
        public SaveInvoiceLineCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.InvoiceLines.Any(line => line.Id == id))
                .WithMessage("The specified invoice line does not exist.");

            RuleFor(x => x.LineItem)
                .GreaterThanOrEqualTo(0).WithMessage("LineItem must be greater than or equal to 0.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.");

            RuleFor(x => x.Unit)
                .GreaterThan(0).WithMessage("Unit must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Total)
                .GreaterThanOrEqualTo(0).WithMessage("Total must be greater than or equal to 0.");

            RuleFor(x => x.BookingId)
                .GreaterThan(0).WithMessage("BookingId must be greater than 0.")
                .Must(id => dbContext.Bookings.Any(booking => booking.Id == id))
                .WithMessage("The specified booking does not exist.");
        }
    }
}
