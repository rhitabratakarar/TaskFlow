using Microsoft.EntityFrameworkCore;
using TaskFlow.Interfaces;
using TaskFlow.Db;

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
}