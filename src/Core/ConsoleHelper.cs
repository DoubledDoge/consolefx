namespace ConsolePrism.Core;

public static class ConsoleHelper
{
    public static void ClearLine(int line)
    {
        Console.SetCursorPosition(0, line);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, line);
    }

    public static void ClearCurrentLine()
    {
        int currentLine = Console.CursorTop;
        ClearLine(currentLine);
    }

    // Cursor Control
    public static void MoveCursor(int x, int y) => Console.SetCursorPosition(x, y);

    public static void HideCursor() => Console.CursorVisible = false;

    public static void ShowCursor() => Console.CursorVisible = true;

    public static (int X, int Y) GetCursorPosition() => (Console.CursorLeft, Console.CursorTop);

    public static (int Width, int Height) GetWindowSize() =>
        (Console.WindowWidth, Console.WindowHeight);

    public static void WriteCentered(string text, int? row = null)
    {
        int x = (Console.WindowWidth - text.Length) / 2;
        int y = row ?? Console.CursorTop;

        if (x < 0)
            x = 0;

        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    public static void WriteRight(string text, int? row = null, int padding = 0)
    {
        int x = Console.WindowWidth - text.Length - padding;
        int y = row ?? Console.CursorTop;

        if (x < 0)
            x = 0;

        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    public static void WriteAt(string text, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    public static void WriteEmptyLines(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine();
        }
    }

    public static string PadCenter(string text, int totalWidth, char paddingChar = ' ')
    {
        if (text.Length >= totalWidth)
            return text;

        int totalPadding = totalWidth - text.Length;
        int leftPadding = totalPadding / 2;
        int rightPadding = totalPadding - leftPadding;

        return new string(paddingChar, leftPadding) + text + new string(paddingChar, rightPadding);
    }

    public static void DrawHorizontalLine(char character = '─') =>
        Console.WriteLine(new string(character, Console.WindowWidth));

    public static void DrawHorizontalLineAt(int y, char character = '─')
    {
        Console.SetCursorPosition(0, y);
        Console.Write(new string(character, Console.WindowWidth));
    }
}
