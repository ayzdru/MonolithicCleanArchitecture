using CleanArchitecture.Core;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Common;

namespace CleanArchitecture.Infrastructure.Data.Interceptors
{
    public class DispatchNotificationsInterceptor : SaveChangesInterceptor
    {
        private readonly IMediator _mediator;

        public DispatchNotificationsInterceptor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchNotifications(eventData.Context).GetAwaiter().GetResult();

            return base.SavingChanges(eventData, result);

        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchNotifications(eventData.Context);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchNotifications(DbContext? context)
        {
            if (context == null) return;

            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.Notifications.Any())
                .Select(e => e.Entity);

            var notifications = entities
                .SelectMany(e => e.Notifications)
                .ToList();

            entities.ToList().ForEach(e => e.ClearNotifications());

            foreach (var notification in notifications)
                await _mediator.Publish(notification);
        }
    }
}
