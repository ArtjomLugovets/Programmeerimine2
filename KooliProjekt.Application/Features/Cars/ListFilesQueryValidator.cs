using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Cars
{
    public class ListFilesQueryValidator : AbstractValidator<ListFilesQuery>
    {
        public ListFilesQueryValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.CarId)
                .GreaterThan(0)
                .Must(id => dbContext.Cars.Any(car => car.Id == id))
                .WithMessage("The specified car does not exist.");
        }
    }
}
