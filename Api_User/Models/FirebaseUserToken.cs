﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api_User.Models
{
    public class FirebaseUserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
    }
}