using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class StatusCreateMapper : ICreateMapper<Status, StatusCreateDTO>
    {
        public Status ToEntity(StatusCreateDTO dto)
        {
            return new Status { Name = dto.Name };
        }
    }
}
