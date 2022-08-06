using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Dtos;

namespace TodoApiDTO.Data
{
    public interface ITodoItemRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemAsync(long id);
        Task CreateTodoItemAsync(TodoItem todoItem);
        Task UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(TodoItem todoItem);
    }
}
