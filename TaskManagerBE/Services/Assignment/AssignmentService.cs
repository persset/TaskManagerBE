using Microsoft.EntityFrameworkCore;
using TaskManagerBE.Data;
using TaskManagerBE.Models;

namespace TaskManagerBE.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly DataContext dataContext;

        public AssignmentService(DataContext context)
        {
            dataContext = context;
        }

        public async Task<Assignment> Create(Assignment entity)
        {
            dataContext.Assignments.Add(entity);

            await dataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Assignment?> Delete(int id)
        {
            var assignment = await dataContext.Assignments.FindAsync(id);

            if (assignment is null)
                return null;

            dataContext.Remove(assignment);

            await dataContext.SaveChangesAsync();

            return assignment;
        }

        public async Task<List<Assignment>> GetAll()
        {
            return await dataContext.Assignments.ToListAsync();
        }

        public async Task<Assignment?> GetSingle(int id)
        {
            var assignment = await dataContext.Assignments.FindAsync(id);

            if (assignment is null)
                return null;

            return assignment;
        }

        public async Task<Assignment?> Update(int id, Assignment entity)
        {
            var assignment = await dataContext.Assignments.FindAsync(id);

            if (assignment is null)
                return null;

            assignment.TaskId = entity.TaskId;
            assignment.UserId = entity.UserId;
            assignment.AssignedAt = entity.AssignedAt;

            await dataContext.SaveChangesAsync();

            return assignment;
        }
    }
}
