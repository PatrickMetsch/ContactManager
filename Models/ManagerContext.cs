using System;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options)
            : base(options)
        { }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "F",
                    CategoryName = "Friend"
                },
                new Category
                {
                    CategoryId = "P",
                    CategoryName = "Professional"
                },
                new Category
                {
                    CategoryId = "M",
                    CategoryName = "Family"
                }
            );

            // spot the Sci Fi references in each of the below phone numbers :)
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    ManagerId = 4,
                    FirstName = "Karen",
                    LastName = "Butterhaven",
                    Phone = "481-516-2342",
                    Email = "karen.butterhaven@helloworld.com",
                    Created = DateTime.Now,
                    Organization = "Galapagos International",
                    CategoryId = "M"

                },
                new Manager
                {
                    ManagerId = 5,
                    FirstName = "Bruce",
                    LastName = "Sourhouse",
                    Phone = "440-488-2001",
                    Email = "karen.butterhaven@helloworld.com",
                    Created = new DateTime(2008, 6, 1, 7, 47, 0),
                    CategoryId = "F"
                },
                new Manager
                {
                    ManagerId = 6,
                    FirstName = "Louis",
                    LastName = "Vanderbloke",
                    Phone = "216-731-1138",
                    Email = "karen.butterhaven@helloworld.com",
                    Created = DateTime.Now,
                    CategoryId = "P"
                }
            );
        }
    }
}
