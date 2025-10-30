namespace ConsolePrism.Core;

using Themes;

public static class ColorWriter
{
    public static void WriteError(string message)
    {
        Console.ForegroundColor = ColorScheme.Error;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ColorScheme.Success;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteWarning(string message)
    {
        Console.ForegroundColor = ColorScheme.Warning;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteInfo(string message)
    {
        Console.ForegroundColor = ColorScheme.Info;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteHighlight(string message)
    {
        Console.ForegroundColor = ColorScheme.Highlight;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteColored(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }

    [Obsolete("Use WriteHighlight instead")]
    public static void WriteHeader(string message) => WriteHighlight(message);

    [Obsolete("Use WriteColored instead")]
    public static void WriteMilestone(string message, ConsoleColor color) =>
        WriteColored(message, color);
}
