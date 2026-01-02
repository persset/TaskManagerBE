using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class UserReadMappers : IReadMapper<User, UserReadDTO>
    {
        public UserReadDTO ToDto(User entity)
        {
            return new UserReadDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };
        }
    }
}
