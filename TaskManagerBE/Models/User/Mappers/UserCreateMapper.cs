using TaskManagerBE.MapperBase;

namespace TaskManagerBE.Models
{
    public class UserCreateMapper : ICreateMapper<User, UserCreateDTO>
    {
        public User ToEntity(UserCreateDTO dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
            };
        }
    }
}
