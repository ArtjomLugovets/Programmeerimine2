using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetFileCommandValidator : AbstractValidator<GetFileCommand>
    {
        public GetFileCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("CarId must be greater than 0.")
                .Must(id => dbContext.Cars.Any(car => car.Id == id))
                .WithMessage("The specified car does not exist.");
        }
    }
}
