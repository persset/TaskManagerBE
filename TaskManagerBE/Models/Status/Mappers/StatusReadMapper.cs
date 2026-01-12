using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class StatusReadMapper : IReadMapper<Status, StatusReadDTO>
    {
        public StatusReadDTO ToDto(Status entity)
        {
            return new StatusReadDTO { Id = entity.Id, Name = entity.Name };
        }
    }
}
