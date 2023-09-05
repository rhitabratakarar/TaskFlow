using TaskFlow.Interfaces;
using TaskFlow.Enums;

namespace TaskFlow.Models;

public class WorkItem : IWorkItem
{
    public int Id { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
}