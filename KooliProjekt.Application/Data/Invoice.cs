using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace KooliProjekt.Application.Data
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime InvoiceDate { get; set; }
        public DateTime Duedate { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<InvoiceLine> InvoiceLines { get; set; }

    }
}
