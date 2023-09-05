using TaskFlow.Interfaces;

namespace TaskFlow.Models;

public class WorkItemsDTO
{
    public IList<IWorkItem>? Todos { get; set; }
    public IList<IWorkItem>? Doing { get; set; }
    public IList<IWorkItem>? Done { get; set; }
}