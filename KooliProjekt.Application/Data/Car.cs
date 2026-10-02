using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace KooliProjekt.Application.Data
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }
        public int CarModelId { get; set; }

        [ForeignKey(nameof(CarModelId))]
        public CarModel CarModel { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
