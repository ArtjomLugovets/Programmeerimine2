using FluentValidation;
using KooliProjekt.Application.Data;
using System.Linq;

namespace KooliProjekt.Application.Features.Users
{
    public class SaveUserCommandValidator : AbstractValidator<SaveUserCommand>
    {
        public SaveUserCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0.")
                .Must(id => id == 0 || dbContext.Users.Any(user => user.Id == id))
                .WithMessage("The specified user does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(25).WithMessage("Name must not exceed 25 characters.")
                .Must((command, name) => !dbContext.Users.Any(user => user.Name == name && user.Id != command.Id))
                .WithMessage("A user with the same name already exists.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(20).WithMessage("Phone must not exceed 20 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.")
                .MaximumLength(150).WithMessage("Email must not exceed 150 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MaximumLength(255).WithMessage("Password must not exceed 255 characters.");
        }
    }
}
