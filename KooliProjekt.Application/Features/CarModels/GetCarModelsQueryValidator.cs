using FluentValidation;

namespace KooliProjekt.Application.Features.CarModels
{
    public class GetCarModelsQueryValidator : AbstractValidator<GetCarModelsQuery>
    {
        public GetCarModelsQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
