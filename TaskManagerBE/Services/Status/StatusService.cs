using Microsoft.EntityFrameworkCore;
using TaskManagerBE.Data;
using TaskManagerBE.Models;

namespace TaskManagerBE.Services
{
    public class StatusService : IStatusService
    {
        private readonly DataContext dataContext;

        public StatusService(DataContext context)
        {
            dataContext = context;
        }

        public async Task<Status> Create(Status entity)
        {
            dataContext.Statuses.Add(entity);

            await dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Status?> Delete(int id)
        {
            var status = await dataContext.Statuses.FindAsync(id);

            if (status is null)
                return null;

            dataContext.Statuses.Remove(status);

            await dataContext.SaveChangesAsync();

            return status;
        }

        public async Task<List<Status>> GetAll()
        {
            return await dataContext.Statuses.ToListAsync();
        }

        public async Task<Status?> GetSingle(int id)
        {
            var status = await dataContext.Statuses.FindAsync(id);

            if (status is null)
                return null;

            return status;
        }

        public async Task<Status?> Update(int id, Status entity)
        {
            var status = await dataContext.Statuses.FindAsync(id);

            if (status is null)
                return null;

            status.Name = entity.Name;

            await dataContext.SaveChangesAsync();

            return status;
        }
    }
}
