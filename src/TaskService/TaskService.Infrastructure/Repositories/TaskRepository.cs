using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskService.Application.Interfaces;
using TaskService.Domain.Entities;
using TaskService.Infrastructure.Persistence;

namespace TaskService.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ProjectTask task, CancellationToken cancellationToken)
        {
            _context.Add(task);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProjectTask>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Tasks
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
