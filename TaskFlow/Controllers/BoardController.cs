using Microsoft.AspNetCore.Mvc;
using TaskFlow.Interfaces;
using TaskFlow.Models;
using TaskFlow.Enums;

public class BoardController : Controller
{
    private readonly ILogger<BoardController> _logger;
    private readonly IBoardService _service;
    public BoardController(ILogger<BoardController> logger, IBoardService service)
    {
        this._logger = logger;
        this._service = service;
    }
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

    //[HttpPost("/moveItem/")]
    //public IActionResult MoveItem(MoveItemDTO dto)
    //{
    //    // moveitemdto => where to move [doing, done, todo], item to move(contains the itemId).
    //    Console.WriteLine(dto.Status);

    //    if(dto.WorkItem != null)
    //        Console.WriteLine(dto.WorkItem.Id);

    //    return Ok();
    //}
}