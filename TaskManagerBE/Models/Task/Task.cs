namespace TaskManagerBE.Models
{
    public class Task : BaseModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime CompletedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
