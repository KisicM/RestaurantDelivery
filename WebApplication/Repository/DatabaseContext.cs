using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasData(
                    new User()
                    {
                        Id = -1,
                        Username = "admin",
                        Password = "ftn",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = true,
                        Image = "",
                        UserRole = UserRole.Admin,
                        DateOfBirth = new DateTime(2022, 06, 25)
                    },
                    new User()
                    {
                        Id = -2,
                        Username = "deliverer",
                        Password = "ftn",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = false,
                        Image = "",
                        UserRole = UserRole.Deliverer,
                        DateOfBirth = new DateTime(2022, 06, 25)
                    },
                    new User()
                    {
                        Id = -3,
                        Username = "customer",
                        Password = "ftn",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = true,
                        Image = "",
                        UserRole = UserRole.Customer,
                        DateOfBirth = new DateTime(2022, 06, 25)
                    }
                );
            });

        }

    }
}