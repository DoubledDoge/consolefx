namespace ConsolePrism.Themes;

// Feel free to change these characters
public static class BorderStyle
{
    public static char TopLeft { get; private set; } = '┌';
    public static char TopRight { get; private set; } = '┐';
    public static char BottomLeft { get; private set; } = '└';
    public static char BottomRight { get; private set; } = '┘';
    public static char Horizontal { get; private set; } = '─';
    public static char Vertical { get; private set; } = '│';
    public static char Cross { get; private set; } = '┼';
    public static char TeeLeft { get; private set; } = '├';
    public static char TeeRight { get; private set; } = '┤';
    public static char TeeTop { get; private set; } = '┬';
    public static char TeeBottom { get; private set; } = '┴';
}
