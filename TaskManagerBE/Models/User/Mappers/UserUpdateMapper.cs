using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class UserUpdateMapper : IUpdateMapper<UserCreateDTO, User>
    {
        public void MapToEntity(UserCreateDTO entity, User dto)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Password = dto.Password;
        }
    }
}
