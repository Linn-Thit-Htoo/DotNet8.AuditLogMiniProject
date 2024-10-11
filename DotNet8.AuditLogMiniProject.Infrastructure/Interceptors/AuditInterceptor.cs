namespace DotNet8.AuditLogMiniProject.Infrastructure.Interceptors;

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

        if (addedEntries.Count != 0)
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

        if (modifiedEntries.Count != 0)
        {
            foreach (var entry in modifiedEntries)
            {
                var entityId = entry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue;
                var audit = new Tbl_Audit
                {
                    UpdatedDate = DateTime.Now,
                    EntityName = entry.Entity.GetType().Name,
                    Operation = "Updated",
                    Id = Convert.ToInt32(entityId)
                };

                await context.Set<Tbl_Audit>().AddAsync(audit, cancellationToken);
            }
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
