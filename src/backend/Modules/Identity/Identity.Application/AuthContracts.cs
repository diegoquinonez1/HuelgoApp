namespace Identity.Application;

public sealed record RegisterUserRequest(
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    string Email,
    string Password,
    string ConfirmPassword);

public sealed record LoginRequest(string Email, string Password);

public sealed record AuthenticatedUser(string UserId, string Email, string FirstName, string LastName);