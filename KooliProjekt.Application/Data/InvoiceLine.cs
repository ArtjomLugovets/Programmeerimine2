using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace KooliProjekt.Application.Data
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public decimal LineItem { get; set; }
        public decimal Price { get; set; }
        public int Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public Invoice Invoice { get; set; }
    }
}
