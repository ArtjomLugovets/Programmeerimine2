using FluentValidation;
using KooliProjekt.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommandValidator : AbstractValidator<SaveCarCommand>
    {
        public SaveCarCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Car).NotNull();
            RuleFor(x => x.Car.Brand).NotEmpty().WithMessage("Brand is required.");
            RuleFor(x => x.Car.Model).NotEmpty().WithMessage("Model is required.");
            RuleFor(x => x.Car.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Year must be between 1900 and {DateTime.Now.Year}.");
            RuleFor(x => x.Car.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
