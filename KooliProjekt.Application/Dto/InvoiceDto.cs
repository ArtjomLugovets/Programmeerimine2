using System;

namespace KooliProjekt.Application.Dto
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime Duedate { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
    }
}
