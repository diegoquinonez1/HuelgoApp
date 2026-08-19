using SQLite;

namespace HuelgoApp.Mobile.Services;

public sealed class OfflineStore
{
    private readonly SQLiteAsyncConnection _database = new(Path.Combine(FileSystem.AppDataDirectory, "huelgoapp.db3"));

    public Task InitializeAsync() => _database.CreateTableAsync<PendingSyncChange>();

    public Task QueueAsync(string entityType, string entityId, string payload) =>
        _database.InsertAsync(new PendingSyncChange { EntityType = entityType, EntityId = entityId, Payload = payload, UpdatedAt = DateTimeOffset.UtcNow });

    public Task<List<PendingSyncChange>> GetPendingAsync() => _database.Table<PendingSyncChange>().OrderBy(change => change.Id).ToListAsync();

    public Task RemoveAsync(IEnumerable<PendingSyncChange> changes) => _database.RunInTransactionAsync(connection =>
    {
        foreach (var change in changes)
        {
            connection.Delete(change);
        }
    });
}

public sealed class PendingSyncChange
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string EntityType { get; set; } = string.Empty;
    public string EntityId { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
    public DateTimeOffset UpdatedAt { get; set; }
}