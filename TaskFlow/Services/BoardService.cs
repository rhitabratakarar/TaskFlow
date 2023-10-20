using Microsoft.EntityFrameworkCore;
using TaskFlow.Interfaces;
using TaskFlow.Db;
using TaskFlow.Enums;
using TaskFlow.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TaskFlow.Services;
public class BoardService : IBoardService
{
    private readonly DatabaseContext _dbContext;
    public BoardService(DatabaseContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<bool> CreateItem(string header, string description, Status status)
    {
        EntityEntry workitem = await _dbContext.WorkItems.AddAsync(new WorkItem() { Header = header, Description = description, Status = status });
        if (workitem != null)
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
            return false;
    }

    public async Task<bool> DeleteItem(int? idToDelete)
    {
        IWorkItem? itemToRemove = await _dbContext.WorkItems.FindAsync(idToDelete);
        if (itemToRemove != null)
        {
            _dbContext.Entry(itemToRemove).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
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