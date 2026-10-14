
using System;
using System.Collections.Generic;
using System.Linq;
using KooliProjekt.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Users.Any()
                || context.CarModels.Any()
                || context.Cars.Any()
                || context.Bookings.Any()
                || context.Invoices.Any()
                || context.InvoiceLines.Any())
            {
                return;
            }

            var users = new List<User>();
            var carModels = new List<CarModel>();
            var cars = new List<Car>();
            var bookings = new List<Booking>();
            var invoices = new List<Invoice>();
            var invoiceLines = new List<InvoiceLine>();

            for (int i = 1; i <= 35; i++)
            {
                users.Add(new User
                {
                    Name = $"customer{i:00}",
                    Phone = $"+372555{i:0000}",
                    Email = $"customer{i:00}@example.com",
                    IsAdmin = i == 1,
                    Password = "ChangeMe123!"
                });
            }

            string[] brands =
            {
                "Toyota Corolla",
                "Toyota Yaris",
                "Toyota RAV4",
                "Škoda Octavia",
                "Škoda Fabia",
                "Škoda Superb",
                "Volkswagen Golf",
                "Volkswagen Passat",
                "Volkswagen Tiguan",
                "BMW 320d",
                "BMW 530d",
                "BMW X3",
                "Audi A3",
                "Audi A4",
                "Audi Q5",
                "Mercedes-Benz C-Class",
                "Mercedes-Benz E-Class",
                "Mercedes-Benz GLC",
                "Volvo V40",
                "Volvo V60",
                "Volvo XC60",
                "Kia Ceed",
                "Kia Sportage",
                "Hyundai i30",
                "Hyundai Tucson",
                "Ford Focus",
                "Ford Kuga",
                "Honda Civic",
                "Honda CR-V",
                "Nissan Qashqai",
                "Mazda 3",
                "Mazda CX-5",
                "Peugeot 308",
                "Renault Clio",
                "Dacia Duster"
            };

            foreach (string brand in brands)
            {
                carModels.Add(new CarModel
                {
                    Name = brand
                });
            }

            for (int i = 0; i < 35; i++)
            {
                cars.Add(new Car
                {
                    RegistrationNumber = $"ABC-{100 + i}",
                    CarModel = carModels[i]
                });
            }

            for (int i = 0; i < 35; i++)
            {
                var started = new DateTime(2026, 1, 1)
                    .AddDays(i * 3);

                bookings.Add(new Booking
                {
                    Started = started,
                    Finished = started.AddDays(1),
                    StartKm = 12000 + i * 850,
                    FinishKm = 12000 + i * 850 + 145,
                    KmRate = 0.35m,
                    HourlyRate = 8.50m,
                    Car = cars[i],
                    User = users[i],
                    InvoiceLines = new List<InvoiceLine>()
                });
            }

            for (int i = 0; i < 35; i++)
            {
                invoices.Add(new Invoice
                {
                    InvoiceDate = bookings[i].Started,
                    Duedate = bookings[i].Started.AddDays(14),
                    User = users[i],
                    IsPaid = i % 3 != 0,
                    InvoiceLines = new List<InvoiceLine>()
                });
            }

            for (int i = 0; i < 35; i++)
            {
                decimal distance =
                    bookings[i].FinishKm - bookings[i].StartKm;

                decimal distanceCost =
                    distance * bookings[i].KmRate;

                decimal hoursCost =
                    24 * bookings[i].HourlyRate;

                decimal total = distanceCost + hoursCost;

                var line = new InvoiceLine
                {
                    LineItem = 1,
                    Price = total,
                    Unit = 1,
                    Quantity = 1,
                    Total = total,
                    Booking = bookings[i],
                    Invoice = invoices[i]
                };

                invoiceLines.Add(line);
                bookings[i].InvoiceLines.Add(line);
                invoices[i].InvoiceLines.Add(line);

                bookings[i].Invoice = invoices[i];
            }

            context.Users.AddRange(users);
            context.CarModels.AddRange(carModels);
            context.Cars.AddRange(cars);
            context.Bookings.AddRange(bookings);
            context.Invoices.AddRange(invoices);
            context.InvoiceLines.AddRange(invoiceLines);

            context.SaveChanges();
        }
    }
}
