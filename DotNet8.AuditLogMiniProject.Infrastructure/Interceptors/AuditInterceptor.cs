using DotNet8.AuditLogMiniProject.Domain.Features.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Infrastructure.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context!;
            var addedEntries = context.ChangeTracker.Entries()
                                      .Where(x => x.State == EntityState.Added)
                                      .ToList();
            var modifiedEntries = context.ChangeTracker.Entries()
                                         .Where(x => x.State == EntityState.Modified)
                                         .ToList();

            if (addedEntries.Any())
            {
                foreach (var entry in addedEntries)
                {
                    var audit = new Tbl_Audit
                    {
                        CreatedDate = DateTime.Now,
                        EntityName = entry.Entity.GetType().Name,
                        Operation = "Created",
                    };

                    await context.Set<Tbl_Audit>().AddAsync(audit, cancellationToken);
                }
            }

            if (modifiedEntries.Any())
            {
                foreach (var entry in modifiedEntries)
                {
                    var entityId = entry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue;
                    var item = await context.Set<Tbl_Audit>().FindAsync(new object?[] { entityId, cancellationToken }, cancellationToken: cancellationToken);
                    ArgumentNullException.ThrowIfNull(item);

                    item.UpdatedDate = DateTime.Now;
                    item.Operation = "Updated";
                    item.EntityName = entry.Entity.GetType().Name;

                    context.Update(item);
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
