namespace ConsolePrism.Components;

using Themes;

public static class ProgressBar
{
    private static void Display(int current, int total, int barWidth = 40, string? label = null)
    {
        if (total <= 0)
            total = 1; // Prevent division by zero and negative progress bars

        if (current > total)
            current = total; // Limit progress to total

        if (current < 0)
            current = 0; // Prevent negative progress bars

        double percentage = (double)current / total;
        int filledWidth = (int)(barWidth * percentage);
        int emptyWidth = barWidth - filledWidth;

        // Optional label
        if (!string.IsNullOrEmpty(label))
        {
            Console.ForegroundColor = ColorScheme.ProgressBarText;
            Console.Write($"{label}: ");
            Console.ResetColor();
        }

        Console.Write("[");

        // Filled portion
        Console.ForegroundColor = ColorScheme.ProgressBarComplete;
        Console.Write(new string('█', filledWidth));
        Console.ResetColor();

        // Empty portion
        Console.ForegroundColor = ColorScheme.ProgressBarIncomplete;
        Console.Write(new string('░', emptyWidth));
        Console.ResetColor();

        // Closing bracket and percentage
        Console.ForegroundColor = ColorScheme.ProgressBarText;
        Console.Write($"] {percentage:P0}");
        Console.ResetColor();
    }

    // For animations
    public static void DisplayInPlace(
        int current,
        int total,
        int barWidth = 40,
        string? label = null
    )
    {
        int startPosition = Console.CursorLeft;
        int linePosition = Console.CursorTop;

        Display(current, total, barWidth, label);

        // Return the cursor to start for the next update
        Console.SetCursorPosition(startPosition, linePosition);
    }
}
