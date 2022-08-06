using System.Collections.Generic;
using TodoApiDTO.Dtos;

namespace TodoApiDTO.Data
{
    public interface ITodoItemRepo
    {
        bool SaveChanges();

        IEnumerable<TodoItem> GetTodoItems();
        TodoItem GetTodoItem(long id);
        void CreateTodoItem(TodoItem todoItem);
        void UpdateTodoItem(TodoItem todoItem);
    }
}
