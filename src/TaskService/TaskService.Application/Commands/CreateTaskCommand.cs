using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using TaskService.Application.Interfaces;
using TaskService.Domain.Entities;
using TaskService.Domain.Events;

namespace TaskService.Application.Commands
{
    public record CreateTaskCommand(string title, string description) : IRequest<ProjectTask>;

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand,ProjectTask>
    {
        private readonly ITaskRepository _repository;
        private readonly IPublisher _publisher;

        public CreateTaskCommandHandler(ITaskRepository repository, IPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }
        public async Task<ProjectTask> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {

            var task = new ProjectTask(request.title, request.description);
            await _repository.AddAsync(task, cancellationToken);
            await _publisher.Publish(new TaskCreated(task.Id, task.Title));
            return task;
        }
    }
}
