using Microsoft.EntityFrameworkCore;
using TaskManagerBE.Data;

namespace TaskManagerBE.Services
{
    public class TaskService : ITaskService
    {
        private readonly DataContext dataContext;

        public TaskService(DataContext context)
        {
            dataContext = context;
        }

        public async Task<Models.Task> Create(Models.Task entity)
        {
            dataContext.Tasks.Add(entity);

            await dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Models.Task?> Delete(int id)
        {
            var task = await dataContext.Tasks.FindAsync(id);

            if (task is null)
                return null;

            dataContext.Tasks.Remove(task);

            await dataContext.SaveChangesAsync();

            return task;
        }

        public async Task<List<Models.Task>> GetAll()
        {
            return await dataContext.Tasks.ToListAsync();
        }

        public async Task<Models.Task?> GetSingle(int id)
        {
            var task = await dataContext.Tasks.FindAsync(id);

            if (task is null)
                return null;

            return task;
        }

        public async Task<Models.Task?> Update(int id, Models.Task entity)
        {
            var task = await dataContext.Tasks.FindAsync(id);

            if (task is null)
                return null;

            task.Title = entity.Title;
            task.Description = entity.Description;
            task.StatusId = entity.StatusId;
            task.DueDate = entity.DueDate;
            task.CompletedAt = entity.CompletedAt;

            await dataContext.SaveChangesAsync();

            return task;
        }
    }
}
