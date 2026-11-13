using FluentValidation;


namespace KooliProjekt.Application.Features.Cars
{
    public class ListCarsQueryValidator : AbstractValidator<ListCarsQuery>
    {
        public ListCarsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        }
    }
}