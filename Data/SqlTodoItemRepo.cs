using System;
using System.Collections.Generic;
using System.Linq;
using TodoApiDTO.Dtos;

namespace TodoApiDTO.Data
{
    public class SqlTodoItemRepo : ITodoItemRepo
    {
        private readonly DataContext _context;

        public SqlTodoItemRepo(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _context.TodoItems.ToList();
        }
        public TodoItem GetTodoItem(long id)
        {
            return _context.TodoItems.FirstOrDefault(p => p.Id == id);
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            if ( todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }

            _context.TodoItems.Add(todoItem);
        }

        public bool SaveChanges()
        {
           return  (_context.SaveChanges() >= 0);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem));
            }
            _context.TodoItems.Remove(todoItem);
        }
    }
}
