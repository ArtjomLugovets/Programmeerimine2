using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Bookings
{
    public class SaveBookingCommandValidator : AbstractValidator<SaveBookingCommand>
    {
        public SaveBookingCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Bookings.Any(item => item.Id == id))
                .WithMessage("The specified booking does not exist.");

            RuleFor(x => x.Started)
                .NotEmpty().WithMessage("Started is required.");

            RuleFor(x => x.Finished)
                .NotEmpty().WithMessage("Finished is required.")
                .Must((command, finished) => finished > command.Started)
                .WithMessage("Finished must be later than Started.");

            RuleFor(x => x.StartKm)
                .GreaterThanOrEqualTo(0).WithMessage("StartKm must be greater than or equal to 0.");

            RuleFor(x => x.FinishKm)
                .GreaterThanOrEqualTo(0).WithMessage("FinishKm must be greater than or equal to 0.")
                .Must((command, finishKm) => finishKm >= command.StartKm)
                .WithMessage("FinishKm must be greater than or equal to StartKm.");

            RuleFor(x => x.KmRate)
                .GreaterThanOrEqualTo(0).WithMessage("KmRate must be greater than or equal to 0.");

            RuleFor(x => x.HourlyRate)
                .GreaterThanOrEqualTo(0).WithMessage("HourlyRate must be greater than or equal to 0.");

            RuleFor(x => x.CarId)
                .GreaterThan(0).WithMessage("CarId must be greater than 0.")
                .Must(id => dbContext.Cars.Any(car => car.Id == id))
                .WithMessage("The specified car does not exist.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.")
                .Must(id => dbContext.Users.Any(user => user.Id == id))
                .WithMessage("The specified user does not exist.");
        }
    }
}
