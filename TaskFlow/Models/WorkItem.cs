using TaskFlow.Interfaces;
using TaskFlow.Enums;
using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Models;

public class WorkItem : IWorkItem
{
    [Key]
    public int Id { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
}