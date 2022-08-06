using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApiDTO.Data
{
    public interface ITodoItemRepo
    {
        bool SaveChanges();

        IEnumerable<TodoItem> GetTodoItems();
        TodoItem GetTodoItem(long id);
        void CreateTodoItem(TodoItem todoItem);
    }
}
