using TaskFlow.Enums;
using TaskFlow.Interfaces;

namespace TaskFlow.Models
{
    public class MoveItemDTO
    {
        public Status Status { get; set; }
        public IWorkItem? WorkItem { get; set; }
    }
}
