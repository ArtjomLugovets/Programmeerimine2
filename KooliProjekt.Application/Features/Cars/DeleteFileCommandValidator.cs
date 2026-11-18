using System.IO;
using System.Linq;
using FluentValidation;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Features.Cars
{
    public class DeleteFileCommandValidator : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("CarId must be greater than 0.")
                .Must(id => dbContext.Cars.Any(car => car.Id == id))
                .WithMessage("The specified car does not exist.");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("FileName is required.")
                .Must(name => !string.IsNullOrWhiteSpace(name) &&
                              name == Path.GetFileName(name) &&
                              name != "." && name != "..")
                .WithMessage("FileName must be a file name without directory paths.");
        }
    }
}
