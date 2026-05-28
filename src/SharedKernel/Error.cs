namespace AiStartupOs.SharedKernel;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new("none", string.Empty);

    public override string ToString() => $"{Code}: {Message}";
}
