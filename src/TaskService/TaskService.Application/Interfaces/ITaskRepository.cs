using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService.Domain.Entities;

namespace TaskService.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task AddAsync(ProjectTask task, CancellationToken cancellationToken);
        Task<IEnumerable<ProjectTask>> GetAllAsync(CancellationToken cancellationToken);
    }
}
