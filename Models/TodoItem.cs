﻿using System.ComponentModel.DataAnnotations;

namespace TodoApiDTO.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}