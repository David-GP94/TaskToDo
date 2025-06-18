using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskService.Application.Interfaces;
using TaskService.Domain.Entities;

namespace TaskService.Application.Queries
{
    public record GetAllTasksQuery : IRequest<IEnumerable<ProjectTask>>;

    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<ProjectTask>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<ProjectTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetAllAsync(cancellationToken);
        }
    }
}
