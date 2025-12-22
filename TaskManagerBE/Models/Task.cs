namespace TaskManagerBE.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int StatusId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CompletedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
