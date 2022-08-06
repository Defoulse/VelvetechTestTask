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
        public async Task<ActionResult<IEnumerable<TodoItemReadDto>>> GetTodoItemsAsync()
        {
            var todoItems = await _repository.GetTodoItemsAsync();
            return Ok(_mapper.Map<IEnumerable<TodoItemReadDto>>(todoItems));
        }

        [HttpGet("{id}", Name = "GetTodoItemAsync")]
        public async Task<ActionResult<TodoItemReadDto>> GetTodoItemAsync(long id)
        {
            var todoItem = await _repository.GetTodoItemAsync(id);
            if (todoItem != null)
            {
                return Ok(_mapper.Map<TodoItemReadDto>(todoItem));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemReadDto>> CreateTodoItemAsync(TodoItemCreateDto todoItemCreateDto)
        {
            var todoItemModel = _mapper.Map<TodoItem>(todoItemCreateDto);
            await _repository.CreateTodoItemAsync(todoItemModel);
            await _repository.SaveChangesAsync();

            var todoItemReadDto = _mapper.Map<TodoItemReadDto>(todoItemModel);

            return CreatedAtRoute(nameof(GetTodoItemAsync), new {Id = todoItemReadDto.Id}, todoItemReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodoItemAsync(long id, TodoItemUpdateDto todoItemUpdateDto)
        {
            var todoItemModel = await _repository.GetTodoItemAsync(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }
            _mapper.Map(todoItemUpdateDto, todoItemModel);

            await _repository.UpdateTodoItemAsync(todoItemModel);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUpdateTodoItem(int id, JsonPatchDocument<TodoItemUpdateDto> patchDoc)
        {
            var todoItemModel = await _repository.GetTodoItemAsync(id);
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
            await _repository.UpdateTodoItemAsync(todoItemModel);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            var todoItemModel = await _repository.GetTodoItemAsync(id);
            if (todoItemModel == null)
            {
                return NotFound();
            }
            await _repository.DeleteTodoItemAsync(todoItemModel);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
