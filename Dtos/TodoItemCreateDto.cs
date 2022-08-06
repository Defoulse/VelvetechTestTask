using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoItemCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}