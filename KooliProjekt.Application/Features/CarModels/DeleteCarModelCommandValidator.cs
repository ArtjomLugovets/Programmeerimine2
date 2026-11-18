using FluentValidation;

namespace KooliProjekt.Application.Features.CarModels
{
    public class DeleteCarModelCommandValidator : AbstractValidator<DeleteCarModelCommand>
    {
        public DeleteCarModelCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
