using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class TaskUpdateMapper : IUpdateMapper<Task, TaskUpdateDTO>
    {
        public void MapToEntity(Task entity, TaskUpdateDTO dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.StatusId = dto.StatusId;
            entity.DueDate = dto.DueDate;
            entity.CompletedAt = dto.CompletedAt;
        }
    }
}
