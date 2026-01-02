namespace TaskManagerBE.Models
{
    public class Assignment : BaseModel
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime AssignedBy { get; set; }
    }
}
