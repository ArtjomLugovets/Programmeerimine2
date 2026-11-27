using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Cars
{
    public class AvailableCar
    {
        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarModelName { get; set; }
    }
}
