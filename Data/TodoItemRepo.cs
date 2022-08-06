using System;
using System.Collections.Generic;
using TodoApiDTO.Dtos;

namespace TodoApiDTO.Data
{
    public class TodoItemRepo : ITodoItemRepo
    {
        public IEnumerable<TodoItem> GetTodoItems()
        {
            var todoItems = new List<TodoItem>
            {
                new TodoItem
                {
                    Id = 0,
                    Name = "First Task",
                    Description = "Something have to do 1",
                    IsComplete = false
                },
                
                new TodoItem
                {
                    Id = 1,
                    Name = "Second Task",
                    Description = "Something have to do 2",
                    IsComplete = false
                },
                
                new TodoItem
                {
                    Id = 2,
                    Name = "Third Task",
                    Description = "Something have to do 3",
                    IsComplete = false
                }
            };

            return todoItems;
        }

        public TodoItem GetTodoItem(long id)
        {
            return new TodoItem
            {
                Id = 0,
                Name = "First Task",
                Description = "Something have to do 1",
                IsComplete = false
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
