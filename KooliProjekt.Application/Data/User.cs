using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    [Index(nameof(Name), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        
        [Required] 
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        [StringLength(255)]
        public string Password{ get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
