using Identity.Domain;
using Sync.Domain;

namespace HuelgoApp.Tests.Unit;

public class RegistrationRulesTests
{
    [Fact]
    public void IsAtLeastThirteen_ReturnsFalse_BeforeThirteenthBirthday()
    {
        var result = RegistrationRules.IsAtLeastThirteen(new DateOnly(2013, 8, 19), new DateOnly(2026, 8, 18));

        Assert.False(result);
    }

    [Fact]
    public void IsAtLeastThirteen_ReturnsTrue_OnThirteenthBirthday()
    {
        var result = RegistrationRules.IsAtLeastThirteen(new DateOnly(2013, 8, 18), new DateOnly(2026, 8, 18));

        Assert.True(result);
    }
}

public class SyncConflictResolverTests
{
    [Fact]
    public void ShouldApply_ReturnsTrue_OnlyForNewerChange()
    {
        var existing = new DateTimeOffset(2026, 8, 18, 12, 0, 0, TimeSpan.Zero);

        Assert.True(SyncConflictResolver.ShouldApply(existing.AddMinutes(1), existing));
        Assert.False(SyncConflictResolver.ShouldApply(existing, existing));
        Assert.False(SyncConflictResolver.ShouldApply(existing.AddMinutes(-1), existing));
    }
}
