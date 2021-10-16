using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccesss.EFCore.Entities
{
    public class SeedData
    {
        public static void SeedDatabase(ApplicationContext context)
        {
            context.Database.Migrate();
            if (context.Products.Count() == 0 && context.Stores.Count() == 0) {
                Product p1 = new Product { Name = "Microphone", Description = "A microphone is a device that translates sound vibrations in the air into electronic signals or scribes them to a recording medium." };
                Product p2 = new Product { Name = "Radio", Description = "Radio is sound communication by radio waves from single broadcast stations to multitudes of individual listeners equipped with radio receivers." };
                Product p3 = new Product { Name = "iPod", Description = "The iPod is a portable music player developed by Apple Computer." };
                Product p4 = new Product { Name = "Radiator", Description = "" };
                Product p5 = new Product { Name = "Scanner", Description = "" };
                Product p6 = new Product { Name = "Toaster", Description = "A toaster is an electric small appliance designed to expose various types of sliced bread to radiant heat, browning the bread so it becomes toast." };
                Product p7 = new Product { Name = "Piano", Description = "" };
                Product p8 = new Product { Name = "Drill", Description = "A drill is a tool primarily used for making round holes or driving fasteners." };

                context.Stores.AddRange(
                    new Store {
                        Name = "Men Store",
                        Address = "Minsk",
                        OperatingMode = "Open 24 hours",
                        Products = new List<Product>() {
                            p1, p2, p3, p4, p5
                        }
                    },
                    new Store {
                        Name = "Web Mall",
                        Address = "Moscow",
                        OperatingMode = "Monday: 11:00-18:00",
                        Products = new List<Product>() {
                            p1, p2, p3
                        }
                    },
                    new Store {
                        Name = "Prima Market",
                        Address = "Brest",
                        Products = new List<Product>() {
                            p5, p6, p7, p8
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
