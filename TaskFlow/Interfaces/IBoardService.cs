namespace TaskFlow.Interfaces;

public interface IBoardService
{
    public Task<IList<IWorkItem>> GetAll();
}