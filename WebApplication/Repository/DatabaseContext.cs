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
                        //jabuka123
                        Password = "$2a$10$UVn74F/yEiUzKWBSGVyzHe2UfpVJ95zY50Q8bz1RFyrAYVfwFAj4i",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = true,
                        Image = "",
                        Role = Role.Admin,
                        DateOfBirth = new DateTime(2022, 06, 25),
                        Status = VerificationStatus.Approved
                    },
                    new User()
                    {
                        Id = -2,
                        Username = "deliverer",
                        //jabuka123
                        Password = "$2a$10$UVn74F/yEiUzKWBSGVyzHe2UfpVJ95zY50Q8bz1RFyrAYVfwFAj4i",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = false,
                        Image = "",
                        Role = Role.Deliverer,
                        DateOfBirth = new DateTime(2022, 06, 25),
                        Status = VerificationStatus.Processing

                    },
                    new User()
                    {
                        Id = -3,
                        Username = "customer",
                        //jabuka123
                        Password = "$2a$10$UVn74F/yEiUzKWBSGVyzHe2UfpVJ95zY50Q8bz1RFyrAYVfwFAj4i",
                        Email = "johndoe@gmail.com",
                        Name = "John",
                        Surname = "Doe",
                        Address = "Novi Sad",
                        Approved = true,
                        Image = "",
                        Role = Role.Customer,
                        DateOfBirth = new DateTime(2022, 06, 25),
                        Status = VerificationStatus.Approved
                    }
                );
            });

            modelBuilder.Entity<Article>(a =>
            {
                a.HasData(
                    new Article()
                    {
                        Id = -1,
                        Name = "Pizza",
                        Ingredients = "smth",
                        Price = 250
                    },
                    new Article()
                    {
                        Id = -2,
                        Name = "Vine",
                        Ingredients = "smth",
                        Price = 250
                    }
                );
            });
            modelBuilder.Entity<Order>(a =>
            {
                a.HasData(
                    new Order()
                    {
                        Id = -1,
                        Address = "Novi Sad",
                        Comment = "Ring",
                        Price = 500,
                        StartTime = new DateTime(2022, 06, 25, 15, 00, 00),
                        EndTime = new DateTime(2022, 06, 25, 15, 05, 00),
                        CustomerId = -3,
                        DelivererId = 0
                    },
                    new Order()
                    {
                        Id = -2,
                        Address = "Novi Sad",
                        Comment = "Ring",
                        Price = 250,
                        StartTime = new DateTime(2022, 06, 25, 15, 00, 00),
                        EndTime = new DateTime(2022, 06, 25, 15, 05, 00),
                        CustomerId = -3,
                        DelivererId = -2
                    }
                );
            });
        }

    }
}