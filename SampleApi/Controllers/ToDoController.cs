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


}

