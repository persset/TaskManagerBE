namespace TaskManagerBE.Models
{
    public class TaskReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int StatusId { get; set; }
        public DateTime CompletedAt { get; set; }
        public DateTime DueDate { get; set; }
        public List<UserReadDTO> AssignedUsers { get; set; } = new List<UserReadDTO>();
    }
}
