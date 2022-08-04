using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApiDTO.Profiles
{
    public class TodoItemsProfile : Profile
    {
        public TodoItemsProfile()
        {
            CreateMap<TodoItem, TodoItemReadDto>();
        }
    }
}
