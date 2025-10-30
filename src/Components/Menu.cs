namespace ConsolePrism.Components;

using Core;
using Themes;

public static class Menu
{
    public static int DisplayNumbered(string title, params string[] options) =>
        DisplayNumbered(title, options.ToList());

    private static int DisplayNumbered(string title, List<string> options)
    {
        Console.Clear();

        // Display title
        Console.ForegroundColor = ColorScheme.MenuTitle;
        ConsoleHelper.WriteCentered(title);
        Console.ResetColor();
        ConsoleHelper.WriteEmptyLines(1);

        // Display options
        for (int i = 0; i < options.Count; i++)
        {
            Console.ForegroundColor = ColorScheme.MenuOption;
            Console.Write($"[{i + 1}]");
            Console.WriteLine(options[i]);
            Console.ResetColor();
        }

        ConsoleHelper.WriteEmptyLines(1);

        // Get user selection
        while (true)
        {
            Console.ForegroundColor = ColorScheme.Primary;
            Console.Write("Select an option: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Count)
            {
                return choice - 1;
            }

            ColorWriter.WriteError("Invalid selection. Please try again.\n");
        }
    }

    public static int DisplayInteractive(string title, params string[] options) =>
        DisplayInteractive(title, options.ToList());

    private static int DisplayInteractive(string title, List<string> options)
    {
        Console.Clear();
        ConsoleHelper.HideCursor();

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            // Display title
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ColorScheme.MenuTitle;
            ConsoleHelper.WriteCentered(title);
            Console.ResetColor();
            ConsoleHelper.WriteEmptyLines(1);

            // Display options
            for (int i = 0; i < options.Count; i++)
            {
                Console.Write(string.Empty);

                if (i == selectedIndex)
                {
                    // Highlight selected option
                    Console.ForegroundColor = ColorScheme.MenuSelected;
                    Console.Write('>');
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ColorScheme.MenuOption;
                    Console.Write(string.Empty);
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }
            }

            ConsoleHelper.WriteEmptyLines(1);
            Console.ForegroundColor = ColorScheme.Muted;
            Console.WriteLine("Use ↑/↓ arrows to navigate, Enter to select");
            Console.ResetColor();

            // Handle input
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = selectedIndex > 0 ? selectedIndex - 1 : options.Count - 1;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = selectedIndex < options.Count - 1 ? selectedIndex + 1 : 0;
                    break;
            }
        } while (key != ConsoleKey.Enter);

        ConsoleHelper.ShowCursor();
        return selectedIndex;
    }

    // Bordered menu with custom styling
    public static int DisplayBordered(string title, params string[] options) =>
        DisplayBordered(title, options.ToList());

    private static int DisplayBordered(string title, List<string> options)
    {
        Console.Clear();

        // Calculate dimensions
        int maxWidth = Math.Max(title.Length, options.Max(o => o.Length)) + 8;
        int menuWidth = Math.Min(maxWidth, Console.WindowWidth - 4);

        // Top border
        Console.ForegroundColor = ColorScheme.MenuBorder;
        Console.WriteLine(
            $"{BorderStyle.TopLeft}{new string(BorderStyle.Horizontal, menuWidth)}{BorderStyle.TopRight}"
        );

        // Title
        Console.Write(BorderStyle.Vertical);
        Console.ForegroundColor = ColorScheme.MenuTitle;
        Console.Write(ConsoleHelper.PadCenter(title, menuWidth - 2));
        Console.ForegroundColor = ColorScheme.MenuBorder;
        Console.WriteLine(BorderStyle.Vertical);

        // Separator
        Console.WriteLine(
            $"{BorderStyle.TeeLeft}{new string(BorderStyle.Horizontal, menuWidth)}{BorderStyle.TeeRight}"
        );

        // Options
        for (int i = 0; i < options.Count; i++)
        {
            Console.ForegroundColor = ColorScheme.MenuBorder;
            Console.Write(BorderStyle.Vertical);
            Console.ForegroundColor = ColorScheme.MenuOption;
            Console.Write($"[{i + 1}] {options[i]}");

            // Pad to menu width
            int padding = menuWidth - 2 - ($"[{i + 1}] {options[i]}".Length);
            Console.Write(new string(' ', Math.Max(0, padding)));

            Console.ForegroundColor = ColorScheme.MenuBorder;
            Console.WriteLine(BorderStyle.Vertical);
        }

        // Bottom border
        Console.WriteLine(
            $"{BorderStyle.BottomLeft}{new string(BorderStyle.Horizontal, menuWidth)}{BorderStyle.BottomRight}"
        );
        Console.ResetColor();

        ConsoleHelper.WriteEmptyLines(1);

        // Get selection
        while (true)
        {
            Console.ForegroundColor = ColorScheme.Primary;
            Console.Write("Select an option: ");
            Console.ResetColor();

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= options.Count)
            {
                return choice - 1;
            }

            ColorWriter.WriteError("Invalid selection. Please try again.\n");
        }
    }
}
