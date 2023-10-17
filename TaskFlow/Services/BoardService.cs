using Microsoft.EntityFrameworkCore;
using TaskFlow.Interfaces;
using TaskFlow.Db;
using TaskFlow.Enums;
using TaskFlow.Models;

namespace TaskFlow.Services;
public class BoardService : IBoardService
{
    private readonly DatabaseContext _dbContext;
    public BoardService(DatabaseContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IList<IWorkItem>> GetAll()
    {
        return await this._dbContext.WorkItems.ToListAsync<IWorkItem>();
    }

    public async Task<bool> UpdateItemStatus(int? idToUpdate, Status statusToUpdateTo)
    {
        if (idToUpdate == null)
            return false;

        IWorkItem? itemToUpdate = await _dbContext.FindAsync<WorkItem>(idToUpdate);
        
        if (itemToUpdate != null)
            itemToUpdate.Status = statusToUpdateTo;
        else
            return false;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}