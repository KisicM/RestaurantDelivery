﻿using System;
using System.Text.Json.Serialization;

namespace Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public UserRole UserRole { get; set; }
        public string Image { get; set; }
        public bool Approved { get; set; }

        public User()
        {
            
        }

        public User(string username, string email, string password, string name, string surname, DateTime dateOfBirth, string address, UserRole userRole, string image, bool approved)
        {
            Username = username;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            UserRole = userRole;
            Image = image;
            Approved = approved;
        }
    }
}