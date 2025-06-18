using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using TaskService.Domain.Events;

namespace NotificationService.Application.Events
{
    public class TaskCreatedEventHandler : INotificationHandler<TaskCreated>
    {
        private readonly INotificationRepository _repository;

        public TaskCreatedEventHandler(INotificationRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(TaskCreated notification, CancellationToken cancellationToken)
        {
            var message = $"Task '{notification.Title}' ID:{notification.Id} was created.";
            var notif = new Notification(message);
            await _repository.AddAsync(notif, cancellationToken);
        }
    }
}
