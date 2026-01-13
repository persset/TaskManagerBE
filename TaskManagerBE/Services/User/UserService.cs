using Microsoft.EntityFrameworkCore;
using TaskManagerBE.Data;

namespace TaskManagerBE.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;

        public UserService(DataContext context)
        {
            dataContext = context;
        }

        public async Task<Models.User> Create(Models.User entity)
        {
            dataContext.Users.Add(entity);

            await dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Models.User?> Delete(int id)
        {
            var user = await dataContext.Users.FindAsync(id);

            if (user is null)
                return null;

            dataContext.Users.Remove(user);

            await dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<Models.User>> GetAll()
        {
            return await dataContext.Users.ToListAsync();
        }

        public async Task<Models.User?> GetSingle(int id)
        {
            var user = await dataContext.Users.FindAsync(id);

            if (user is null)
                return null;

            return user;
        }

        public async Task<Models.User?> Update(int id, Models.User entity)
        {
            var user = await dataContext.Users.FindAsync(id);

            if (user is null)
                return null;

            user.Name = entity.Name;
            user.Email = entity.Email;

            await dataContext.SaveChangesAsync();

            return user;
        }
    }
}
