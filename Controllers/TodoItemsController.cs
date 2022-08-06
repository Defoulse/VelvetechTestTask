using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiDTO.Data;
using TodoApiDTO.Dtos;

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

        [HttpGet("{id}", Name = "GetTodoItem")]
        public ActionResult<TodoItemReadDto> GetTodoItem(long id)
        {
            var todoItem = _repository.GetTodoItem(id);
            if (todoItem != null)
            {
                return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TodoItemReadDto> CreateTodoItem(TodoItemCreateDto todoItemCreateDto)
        {
            var todoItemModel = _mapper.Map<TodoItem>(todoItemCreateDto);
            _repository.CreateTodoItem(todoItemModel);
            _repository.SaveChanges();

            var todoItemReadDto = _mapper.Map<TodoItemReadDto>(todoItemModel);

            return CreatedAtRoute(nameof(GetTodoItem), new {Id = todoItemReadDto.Id}, todoItemReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTodoItem(long id, TodoItemUpdateDto todoItemUpdateDto)
        {
            var todoItemModel = _repository.GetTodoItem(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }
            _mapper.Map(todoItemUpdateDto, todoItemModel);

            _repository.UpdateTodoItem(todoItemModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateTodoItem(int id, JsonPatchDocument<TodoItemUpdateDto> patchDoc)
        {
            var todoItemModel = _repository.GetTodoItem(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }

            var todoItemToPatch = _mapper.Map<TodoItemUpdateDto>(todoItemModel);
            patchDoc.ApplyTo(todoItemToPatch, ModelState);
            if (!TryValidateModel(todoItemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(todoItemToPatch, todoItemModel);
            _repository.UpdateTodoItem(todoItemModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(long id)
        {
            var todoItemModel = _repository.GetTodoItem(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }
            _repository.DeleteTodoItem(todoItemModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
