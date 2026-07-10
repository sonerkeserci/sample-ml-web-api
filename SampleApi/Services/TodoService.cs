using Microsoft.AspNetCore.Http.HttpResults;
using SampleApi.Models;
using SampleApi.Requests;

namespace SampleApi.Services
{
    public class TodoService
    {
        private static List<ToDoItem> _todos = new List<ToDoItem> {
            new ToDoItem { Id = 1, Title = "Sample ToDo", IsDone = true },
            new ToDoItem { Id = 2, Title = "Sample ToDo 2", IsDone = false }
        };

        public List<ToDoItem> GetAll()
        {
            return _todos;
        }

        public ToDoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public ToDoItem Create(CreateTodoRequest request)
        {
            var item = new ToDoItem
            {
                Id = _todos.Count + 1,
                Title = request.Title,
                IsDone = request.IsDone
            };

            _todos.Add(item);
            return item;
        }

        public ToDoItem? Update(int id, UpdateTodoRequest request)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item== null)
                return null;

            item.Title = request.Title;
            item.IsDone = request.IsDone;
            return item;
        }

        public bool Delete(int id)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item == null)
                return false;
            _todos.Remove(item);
            return true;
        }




    }
}
