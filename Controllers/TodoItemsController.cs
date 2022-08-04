using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Dtos;
using TodoApi.Models;
using TodoApiDTO.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepo _repository;
        private readonly IMapper _mapper;

        public TodoItemsController(ITodoItemRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItemReadDto>> GetTodoItems()
        {
            var todoItems = _repository.GetTodoItems();
            return Ok(_mapper.Map<IEnumerable<TodoItemReadDto>>(todoItems));
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItemReadDto> GetTodoItem(long id)
        {
            var todoItem = _repository.GetTodoItem(id);
            if (todoItem != null)
            {
                return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            }
            return NotFound();
        }
    }
}
