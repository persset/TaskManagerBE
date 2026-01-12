using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class StatusUpdateMapper : IUpdateMapper<Status, StatusUpdateDTO>
    {
        public void MapToEntity(Status entity, StatusUpdateDTO dto)
        {
            entity.Name = dto.Name;
        }
    }
}
