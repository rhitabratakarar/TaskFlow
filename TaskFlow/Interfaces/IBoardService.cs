using TaskFlow.Enums;
namespace TaskFlow.Interfaces;

public interface IBoardService
{
    public Task<IList<IWorkItem>> GetAll();
    public Task<bool> UpdateItemStatus(int? idToUpdate, Status statusToUpdateTo);
    public Task<bool> DeleteItem(int? idToDelete);
    public Task<bool> CreateItem(string header, string description, Status status);
}