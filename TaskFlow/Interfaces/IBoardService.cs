using TaskFlow.Enums;
namespace TaskFlow.Interfaces;

public interface IBoardService
{
    public Task<IList<IWorkItem>> GetAll();
    public Task<bool> UpdateItemStatus(int? idToUpdate, Status statusToUpdateTo);
}