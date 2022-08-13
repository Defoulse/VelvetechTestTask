using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiDTO.Models;

namespace TodoApiDTO.Data
{
    public class SqlTodoItemRepo : ITodoItemRepo
    {
        private readonly DataContext _context;

        public SqlTodoItemRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
        public async Task<TodoItem> GetTodoItemAsync(long id)
        {
            return await _context.TodoItems.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateTodoItemAsync(TodoItem todoItem)
        {
            if ( todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }

            await _context.TodoItems.AddAsync(todoItem);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            await Task.CompletedTask;
        }

        public async Task DeleteTodoItemAsync(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }
            _context.TodoItems.Remove(todoItem);
            await Task.CompletedTask;
        }
    }
}
