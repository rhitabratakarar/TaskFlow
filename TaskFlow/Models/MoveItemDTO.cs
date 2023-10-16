using TaskFlow.Enums;
using TaskFlow.Interfaces;

namespace TaskFlow.Models
{
    public class MoveItemDTO
    {
        public string? Status { get; set; }
        public int? WorkItemId { get; set; }
    }
}
