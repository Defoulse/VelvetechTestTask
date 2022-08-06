using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoItemCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}