using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommandValidator : AbstractValidator<SaveCarCommand>
    {
        public SaveCarCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must((command, id) => id == 0 || dbContext.Cars.Any(car => car.Id == id))
                .WithMessage("The specified car does not exist.");

            RuleFor(x => x.RegistrationNumber)
                .NotEmpty().WithMessage("RegistrationNumber is required.")
                .MaximumLength(20).WithMessage("RegistrationNumber must not exceed 20 characters.");

            RuleFor(x => x.CarModelId)
                .GreaterThan(0).WithMessage("CarModelId must be greater than 0.")
                .Must(id => dbContext.CarModels.Any(model => model.Id == id))
                .WithMessage("The specified car model does not exist.");
        }
    }
}
