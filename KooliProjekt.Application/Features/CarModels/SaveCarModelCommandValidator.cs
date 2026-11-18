using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.CarModels
{
    public class SaveCarModelCommandValidator : AbstractValidator<SaveCarModelCommand>
    {
        public SaveCarModelCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.CarModels.Any(model => model.Id == id))
                .WithMessage("The specified car model does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        }
    }
}
