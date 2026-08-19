namespace Sync.Domain;

public sealed class SyncRecord
{
    public Guid Id { get; set; }
    public required string UserId { get; set; }
    public required string EntityType { get; set; }
    public required string EntityId { get; set; }
    public required string Payload { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}

public static class SyncConflictResolver
{
    public static bool ShouldApply(DateTimeOffset incomingUpdatedAt, DateTimeOffset existingUpdatedAt) => incomingUpdatedAt > existingUpdatedAt;
}