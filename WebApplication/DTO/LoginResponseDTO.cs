﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurnameName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }

        public LoginResponseDTO(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
            Token = token;
        }
    }
}
