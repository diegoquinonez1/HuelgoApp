namespace Sync.Application;

public sealed record SyncChange(string EntityType, string EntityId, string Payload, DateTimeOffset UpdatedAt, DateTimeOffset? DeletedAt);
public sealed record PushSyncRequest(IReadOnlyCollection<SyncChange> Changes);
public sealed record PullSyncResponse(DateTimeOffset ServerTime, IReadOnlyCollection<SyncChange> Changes);