using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class TaskCreateMapper : ICreateMapper<Task, TaskCreateDTO>
    {
        public Task ToEntity(TaskCreateDTO dto)
        {
            return new Task
            {
                Title = dto.Title,
                Description = dto.Description,
                StatusId = dto.StatusId,
                DueDate = dto.DueDate,
            };
        }
    }
}
