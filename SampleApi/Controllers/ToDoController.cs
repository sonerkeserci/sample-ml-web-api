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
    public async Task<ActionResult<List<ToDoItem>>> Get()
    {
        var items = await _todoService.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetById(int id)
    {
        var item = await _todoService.GetById(id);
        if (item == null) 
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateTodoRequest request)
    {
        var item = await _todoService.Create(request);
        return Ok(item);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<List<ToDoItem>>> Update(int id, UpdateTodoRequest request)
    {
        var item = await _todoService.Update(id, request);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ToDoItem>>> Delete(int id)
    {
        var deleted = await _todoService.Delete(id);

        if(!deleted)
            return NotFound();

        return NoContent();
    }

}





