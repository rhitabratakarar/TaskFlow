using Microsoft.AspNetCore.Mvc;
using TaskFlow.Interfaces;

public class BoardController : Controller
{
    private readonly ILogger<BoardController> _logger;
    private readonly IBoardService _service;
    public BoardController(ILogger<BoardController> logger, IBoardService service)
    {
        this._logger = logger;
        this._service = service;
    }
    public IActionResult Index()
    {
        return View();
    }
}