using Microsoft.EntityFrameworkCore;
using TaskFlow.Interfaces;
// using TaskFlow.Db;
using TaskFlow.Models;

namespace TaskFlow.Services;
public class BoardService : IBoardService
{
    // private readonly DatabaseContext dbContext;
    // public BoardService(DatabaseContext dbContext)
    public BoardService()
    {
        
    }

    public async Task<IList<IWorkItem>> GetAll()
    {
        IList<IWorkItem> items = new List<IWorkItem>()
        {
            new WorkItem() { Description= "this is work", Header= "this is header", Id=1, Status=Enums.Status.Todo },
            new WorkItem() { Description= "this is work", Header= "this is header2", Id=2, Status=Enums.Status.Todo },
            new WorkItem() { Description= "this is work", Header= "this is header3", Id=3, Status=Enums.Status.Todo }
        };
        // return await dbContext.WorkItems.ToListAsync();
        return items;
    }
}