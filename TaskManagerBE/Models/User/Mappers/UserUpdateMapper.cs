using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class UserUpdateMapper : IUpdateMapper<User, UserUpdateDTO>
    {
        public void MapToEntity(User entity, UserUpdateDTO dto)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Password = dto.Password;
        }
    }
}
