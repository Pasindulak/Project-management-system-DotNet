﻿using System.ComponentModel.DataAnnotations;

namespace PMS_Net.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
