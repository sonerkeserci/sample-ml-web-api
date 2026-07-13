using SampleApi.Models;
using SampleApi.Requests;
using SampleApi.Data;
using Microsoft.EntityFrameworkCore;

namespace SampleApi.Services
{
    public class TodoService
    {
        private readonly AppDbContext _dbContext;
        public TodoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // "async" indicates that this method is asynchronous.
        // There is a process within this method that may take some time to complete, and I will wait for it using "await".
        public async Task<List<ToDoItem>> GetAll()      // "Task" indicates that this method will return a list of ToDoItem objects when awaited
        {
            return await _dbContext.ToDoItems.ToListAsync();    // Fetch all ToDoItems from the database
                                                                // SELECT * FROM ToDoItems;
        }

        public async Task<ToDoItem?> GetById(int id)   
        {
            return await _dbContext.ToDoItems.FindAsync(id);    // SELECT * FROM ToDoItems WHERE Id =id;
                                                                // If the item with the specified id is not found, it will return null, otherwise it will return the ToDoItem object
                                                                // The "?" after ToDoItem indicates that this method may return a null value
        }

        public async Task<ToDoItem> Create(CreateTodoRequest request)
        {
            var item = new ToDoItem
            {
                Title = request.Title,
                IsDone = request.IsDone
            };

            _dbContext.ToDoItems.Add(item);         // Add the new ToDoItem to the database context but not yet saved to the database
            await _dbContext.SaveChangesAsync();    // Save the changes to the database
            return item;
        }

        public async Task<ToDoItem?> Update(int id, UpdateTodoRequest request)
        {
            var item = await _dbContext.ToDoItems.FindAsync(id);
            if (item == null)
                return null;

            item.Title = request.Title;
            item.IsDone = request.IsDone;

            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.ToDoItems.FindAsync(id);
            if (item == null)
                return false;
            _dbContext.ToDoItems.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }




    }
}
