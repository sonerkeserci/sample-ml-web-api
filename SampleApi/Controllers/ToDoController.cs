using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;
using SampleApi.Requests;
using SampleApi.Services;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly TodoService _todoService;
    public ToDoController(TodoService todoService)
    {
        _todoService = todoService;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_todoService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetById(int id)
    {
        var item = _todoService.GetById(id);
        if (item == null) 
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public IActionResult Create(CreateTodoRequest request)
    {

        return Ok(_todoService.Create(request));
    }

    [HttpPut("{id}")]

    public ActionResult<ToDoItem> Update(int id, UpdateTodoRequest request)
    {
        var item = _todoService.Update(id, request);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public ActionResult<ToDoItem> Delete(int id)
    {
        var deleted = _todoService.Delete(id);

        if(!deleted)
            return NotFound();

        return NoContent();
    }

}





