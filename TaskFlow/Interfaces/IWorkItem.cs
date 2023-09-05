namespace TaskFlow.Interfaces;
using System.ComponentModel.DataAnnotations;
using TaskFlow.Enums;

public interface IWorkItem
{
    [Key]
    public int Id { get; set; }
    public string? Header { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
}