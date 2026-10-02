using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace KooliProjekt.Application.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public decimal StartKm { get; set; }
        public decimal FinishKm { get; set; }
        public decimal KmRate { get; set; }
        public decimal HourlyRate { get; set; }

        public int CarId { get; set; }
        public int UserId { get; set; }


        public Car Car { get; set; }
        public User User { get; set; }

        public Invoice Invoice { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
