namespace ConsolePrism.Themes;

// Feel free to change these colors
public static class ColorScheme
{
    // Semantic Colors
    public static ConsoleColor Error { get; private set; } = ConsoleColor.Red;
    public static ConsoleColor Success { get; private set; } = ConsoleColor.Green;
    public static ConsoleColor Warning { get; private set; } = ConsoleColor.Yellow;
    public static ConsoleColor Info { get; private set; } = ConsoleColor.Cyan;
    public static ConsoleColor Highlight { get; private set; } = ConsoleColor.Magenta;

    // UI Element Colors
    public static ConsoleColor Primary { get; private set; } = ConsoleColor.Blue;
    public static ConsoleColor Muted   { get; private set; } = ConsoleColor.DarkGray;

    // Component-Specific Colors
    public static ConsoleColor MenuTitle { get; private set; } = ConsoleColor.Yellow;
    public static ConsoleColor MenuOption { get; private set; } = ConsoleColor.White;
    public static ConsoleColor MenuSelected { get; private set; } = ConsoleColor.Green;
    public static ConsoleColor MenuBorder { get; private set; } = ConsoleColor.DarkGray;

    public static ConsoleColor TableHeader { get; private set; } = ConsoleColor.Cyan;
    public static ConsoleColor TableBorder { get; private set; } = ConsoleColor.DarkGray;
    public static ConsoleColor TableData { get; private set; } = ConsoleColor.White;

    public static ConsoleColor ProgressBarComplete { get; private set; } = ConsoleColor.Green;
    public static ConsoleColor ProgressBarIncomplete { get; private set; } = ConsoleColor.DarkGray;
    public static ConsoleColor ProgressBarText { get; private set; } = ConsoleColor.White;
}
