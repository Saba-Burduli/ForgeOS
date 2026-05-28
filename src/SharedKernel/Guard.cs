namespace AiStartupOs.SharedKernel;

public static class Guard
{
    public static T AgainstNull<T>(T? value, string name)
        where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(name);
        }

        return value;
    }

    public static string AgainstNullOrWhiteSpace(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", name);
        }

        return value;
    }

    public static int AgainstOutOfRange(int value, int min, int max, string name)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(name, value, $"Value must be between {min} and {max}.");
        }

        return value;
    }
}
