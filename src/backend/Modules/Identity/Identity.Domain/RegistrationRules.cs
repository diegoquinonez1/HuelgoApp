namespace Identity.Domain;

public static class RegistrationRules
{
    public static bool IsAtLeastThirteen(DateOnly birthDate, DateOnly today)
    {
        var age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
        {
            age--;
        }

        return age >= 13;
    }
}