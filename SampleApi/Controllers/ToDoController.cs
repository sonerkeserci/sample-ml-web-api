using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;
using SampleApi.Requests;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private static List<ToDoItem> _todos = new List<ToDoItem>
    {
        new ToDoItem { Id = 1, Title = "Sample ToDo", IsDone = true },

        new ToDoItem { Id = 2, Title = "Sample ToDo 2", IsDone = false }
    };


    [HttpGet]
    public IActionResult Get()
    {

        return Ok(_todos);
    }

    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetById(int id)
    {
        var item = _todos.FirstOrDefault(t => t.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);

    }

    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {
        var item = new ToDoItem
        {
            Id = _todos.Count + 1,
            Title = request.Title,
            IsDone = request.IsDone
        };

        _todos.Add(item);

        return Ok(item);
    }

    [HttpPut("{id}")]

    public ActionResult<ToDoItem> Update(int id, UpdateTodoRequest request)
    {
        var item = _todos.FirstOrDefault(t => t.Id == id);
        if (item == null)
            return NotFound();

        item.Title = request.Title;
        item.IsDone = request.IsDone;


        return Ok(item);
    }

    [HttpDelete("{id}")]
    public ActionResult<ToDoItem> Delete(int id)
    {
        var item = _todos.FirstOrDefault(t => t.Id == id);
        if(item == null)
            return NotFound();

        _todos.Remove(item);
        return NoContent();
    }

}





