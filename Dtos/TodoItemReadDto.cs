﻿using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoItemReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}