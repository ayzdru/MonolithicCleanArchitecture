using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Notifications
{
    public class TodoListItemCreatedNotification : INotification
    {
        public string Title { get; set; }
        public class TodoListCreatedNotificationHandler : INotificationHandler<TodoListItemCreatedNotification>
        {
            public Task Handle(TodoListItemCreatedNotification notification, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}
