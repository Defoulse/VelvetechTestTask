using AutoMapper;
using TodoApiDTO.Models;

namespace TodoApiDTO.Profiles
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            CreateMap<TodoItem, TodoItemReadDto>();
            CreateMap<TodoItemCreateDto, TodoItem>();
            CreateMap<TodoItemUpdateDto, TodoItem>();
            CreateMap<TodoItem, TodoItemUpdateDto>();
        }
    }
}
