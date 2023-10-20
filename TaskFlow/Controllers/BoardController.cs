using Microsoft.AspNetCore.Mvc;
using TaskFlow.Interfaces;
using TaskFlow.Models;
using TaskFlow.Enums;

namespace TaskFlow.Controllers;

public class BoardController : Controller
{
    private readonly ILogger<BoardController> _logger;
    private readonly IBoardService _service;
    public BoardController(ILogger<BoardController> logger, IBoardService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("/")]
    public async Task<ActionResult<WorkItemsDTO>> Index()
    {
        IList<IWorkItem> workitems = await _service.GetAll();
        WorkItemsDTO dto = new()
        {
            Todos = workitems.Where(item => item.Status == Status.Todo).ToList(),
            Doing = workitems.Where(item => item.Status == Status.Doing).ToList(),
            Done = workitems.Where(item => item.Status == Status.Done).ToList()
        };
        return View(dto);
    }

    [HttpPut("/")]
    public async Task<IActionResult> MoveItem(MoveItemDTO dto)
    {
        _ = Enum.TryParse(dto.Status, out Status ItemStatusToUpdate);
        bool isSuccess = await _service.UpdateItemStatus(dto.WorkItemId, ItemStatusToUpdate);
        if (isSuccess)
            return StatusCode(StatusCodes.Status200OK);
        else
            return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("/")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        bool isItemDeleted = await _service.DeleteItem(id);
        if (isItemDeleted)
            return StatusCode(StatusCodes.Status200OK);
        else
            return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("/")]
    public async Task<IActionResult> CreateItem(NewWorkItemDTO newItem)
    {
        _ = Enum.TryParse(newItem.Status, out Status status);
        bool hasCreated = await _service.CreateItem(newItem.Header!, newItem.Description!, status);
        if (hasCreated)
            return StatusCode(StatusCodes.Status200OK);
        else
            return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("/Todos")]
    public async Task<PartialViewResult> GetTodosListPartialView()
    {
        IList<IWorkItem> itemsList = await _service.GetListOfTodoItems();
        return PartialView("_Todos", itemsList);
    }

    [HttpGet("/Doing")]
    public async Task<IActionResult> GetDoingListPartialView()
    {
        IList<IWorkItem> itemsList = await _service.GetListOfDoingItems();
        return PartialView("_Doing", itemsList);
    }

    [HttpGet("/Done")]
    public async Task<IActionResult> GetDoneListPartialView()
    {
        IList<IWorkItem> itemsList = await _service.GetListOfDoneItems();
        return PartialView("_Done", itemsList);
    }
}