﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        
        [Required]
        public string? Address { get; set; }
    }
}
