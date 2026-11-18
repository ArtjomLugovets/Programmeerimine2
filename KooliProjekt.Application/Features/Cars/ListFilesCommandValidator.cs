using FluentValidation;

namespace KooliProjekt.Application.Features.Cars
{
    // This request currently has no input properties to validate.
    public class ListFilesCommandValidator : AbstractValidator<ListFilesCommand>
    {
        public ListFilesCommandValidator()
        {
        }
    }
}
