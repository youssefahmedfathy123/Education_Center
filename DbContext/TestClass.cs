using Education_Center_DbContext;
using Education_Center_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_DbContext
{
    public class TestClass : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TestClass(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
    DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if (context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            var userId = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "System";

            foreach (var entry in context.ChangeTracker.Entries())
            {
                var entityType = entry.Entity.GetType();

                if (entityType.BaseType != null && entityType.BaseType.IsGenericType &&
                    entityType.BaseType.GetGenericTypeDefinition() == typeof(Entity<>))
                {

                    if (entry.State == EntityState.Added)
                    {
                        var createdAtProp = entityType.GetProperty(nameof(Entity<int>.CreatedOn));
                        var createdByProp = entityType.GetProperty(nameof(Entity<int>.CreatedBy));


                        createdAtProp?.SetValue(entry.Entity, DateTime.UtcNow);

                        if (!string.IsNullOrEmpty(userId))
                        {
                            createdByProp?.SetValue(entry.Entity, userId);
                        }
                    }
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}

