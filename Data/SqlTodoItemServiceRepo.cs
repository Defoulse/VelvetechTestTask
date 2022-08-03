using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApiDTO.Data
{
    public class SqlTodoItemServiceRepo : ITodoItemServiceRepo
    {
        private readonly DataContext _context;

        public SqlTodoItemServiceRepo(DataContext context)
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
    }
}
