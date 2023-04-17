﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}