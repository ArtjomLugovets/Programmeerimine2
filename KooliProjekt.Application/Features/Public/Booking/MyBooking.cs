using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Public.Booking
{
    public class MyBooking
    {
        public int Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public decimal StartKm { get; set; }
        public decimal FinishKm { get; set; }
        public decimal KmRate { get; set; }
        public decimal HourlyRate { get; set; }

        public int CarId { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarModelName { get; set; }
    }
}
