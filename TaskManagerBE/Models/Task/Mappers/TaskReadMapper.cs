using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class TaskReadMapper : IReadMapper<Task, TaskReadDTO>
    {
        public TaskReadDTO ToDto(Task entity)
        {
            return new TaskReadDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                StatusId = entity.StatusId,
                DueDate = entity.DueDate,
                CompletedAt = entity.CompletedAt,
            };
        }
    }
}
