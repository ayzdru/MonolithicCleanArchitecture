using CleanArchitecture.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notifications
{
    public class TodoListCreatedNotification : BaseNotification
    {
        public string Title { get; set; }
        public class TodoListCreatedNotificationHandler : INotificationHandler<TodoListCreatedNotification>
        {
            public Task Handle(TodoListCreatedNotification notification, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
