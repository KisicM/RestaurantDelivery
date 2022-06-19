using System;
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
        public Role Role { get; set; }
        public string Image { get; set; }
        public bool Approved { get; set; }
        public VerificationStatus Status { get; set; }

        public User()
        {
            
        }

        public User(string username, string email, string password, string name, string surname, DateTime dateOfBirth, string address, Role role, string image, bool approved, VerificationStatus status)
        {
            Username = username;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            Role = role;
            Image = image;
            Approved = approved;
            Status = status;
        }
    }
}