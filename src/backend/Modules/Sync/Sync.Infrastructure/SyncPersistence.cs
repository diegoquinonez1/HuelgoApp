using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sync.Application;
using Sync.Domain;

namespace Sync.Infrastructure;

public sealed class SyncDbContext(DbContextOptions<SyncDbContext> options) : DbContext(options)
{
    public DbSet<SyncRecord> Records => Set<SyncRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("sync");
        builder.Entity<SyncRecord>(entity =>
        {
            entity.HasKey(record => record.Id);
            entity.HasIndex(record => new { record.UserId, record.EntityType, record.EntityId }).IsUnique();
            entity.Property(record => record.UserId).HasMaxLength(128);
            entity.Property(record => record.EntityType).HasMaxLength(128);
        });
    }
}

public sealed class SyncService(SyncDbContext dbContext)
{
    public async Task PushAsync(string userId, IEnumerable<SyncChange> changes, CancellationToken cancellationToken)
    {
        foreach (var change in changes)
        {
            var existing = await dbContext.Records.SingleOrDefaultAsync(record => record.UserId == userId && record.EntityType == change.EntityType && record.EntityId == change.EntityId, cancellationToken);
            if (existing is null)
            {
                dbContext.Records.Add(new SyncRecord
                {
                    Id = Guid.NewGuid(), UserId = userId, EntityType = change.EntityType, EntityId = change.EntityId,
                    Payload = change.Payload, UpdatedAt = change.UpdatedAt, DeletedAt = change.DeletedAt
                });
            }
            else if (SyncConflictResolver.ShouldApply(change.UpdatedAt, existing.UpdatedAt))
            {
                existing.Payload = change.Payload;
                existing.UpdatedAt = change.UpdatedAt;
                existing.DeletedAt = change.DeletedAt;
            }
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PullSyncResponse> PullAsync(string userId, DateTimeOffset? since, CancellationToken cancellationToken)
    {
        var serverTime = DateTimeOffset.UtcNow;
        var records = await dbContext.Records.Where(record => record.UserId == userId && (!since.HasValue || record.UpdatedAt > since))
            .OrderBy(record => record.UpdatedAt).ToListAsync(cancellationToken);
        return new PullSyncResponse(serverTime, records.Select(record => new SyncChange(record.EntityType, record.EntityId, record.Payload, record.UpdatedAt, record.DeletedAt)).ToArray());
    }
}

public static class SyncModuleServiceCollectionExtensions
{
    public static IServiceCollection AddSyncModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SyncDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<SyncService>();
        return services;
    }
}