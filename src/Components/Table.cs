namespace ConsolePrism.Components;

using Core;
using Themes;

public static class Table
{
    // Main display method
    public static void Display(string[] headers, string[,]? data, int[]? columnWidths = null)
    {
        if (headers.Length == 0)
        {
            ColorWriter.WriteError("Table requires at least one header.\n");
            return;
        }

        int rowCount = data?.GetLength(0) ?? 0;

        // Calculate column widths if not provided
        int[] widths = columnWidths ?? CalculateColumnWidths(headers, data);

        // Draw table
        DrawTopBorder(widths);
        DrawHeaderRow(headers, widths);
        DrawSeparator(widths);

        if (rowCount > 0)
        {
            DrawDataRows(data, widths);
        }

        DrawBottomBorder(widths);
    }
    
    private static int[] CalculateColumnWidths(string[] headers, string[,]? data)
    {
        int columnCount = headers.Length;
        int[] widths = new int[columnCount];

        // Start with header widths
        for (int col = 0; col < columnCount; col++)
        {
            widths[col] = headers[col].Length;
        }

        // Check data widths
        if (data != null)
        {
            int rowCount = data.GetLength(0);
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    string cellValue = data[row, col];
                    widths[col] = Math.Max(widths[col], cellValue.Length);
                }
            }
        }

        // Add padding
        for (int i = 0; i < widths.Length; i++)
        {
            widths[i] += 2;
        }

        return widths;
    }

    private static void DrawTopBorder(int[] widths)
    {
        Console.ForegroundColor = ColorScheme.TableBorder;
        Console.Write(BorderStyle.TopLeft);

        for (int i = 0; i < widths.Length; i++)
        {
            Console.Write(new string(BorderStyle.Horizontal, widths[i]));
            if (i < widths.Length - 1)
                Console.Write(BorderStyle.TeeTop);
        }

        Console.WriteLine(BorderStyle.TopRight);
        Console.ResetColor();
    }

    private static void DrawHeaderRow(string[] headers, int[] widths)
    {
        Console.ForegroundColor = ColorScheme.TableBorder;
        Console.Write(BorderStyle.Vertical);

        for (int i = 0; i < headers.Length; i++)
        {
            Console.ForegroundColor = ColorScheme.TableHeader;
            string paddedHeader = PadCell(headers[i], widths[i]);
            Console.Write(paddedHeader);

            Console.ForegroundColor = ColorScheme.TableBorder;
            Console.Write(BorderStyle.Vertical);
        }

        Console.WriteLine();
        Console.ResetColor();
    }

    private static void DrawSeparator(int[] widths)
    {
        Console.ForegroundColor = ColorScheme.TableBorder;
        Console.Write(BorderStyle.TeeLeft);

        for (int i = 0; i < widths.Length; i++)
        {
            Console.Write(new string(BorderStyle.Horizontal, widths[i]));
            if (i < widths.Length - 1)
                Console.Write(BorderStyle.Cross);
        }

        Console.WriteLine(BorderStyle.TeeRight);
        Console.ResetColor();
    }

    private static void DrawDataRows(string[,]? data, int[] widths)
    {
        if (data == null)
            return;
        int rowCount = data.GetLength(0);
        int columnCount = data.GetLength(1);

        for (int row = 0; row < rowCount; row++)
        {
            List<string[]> wrappedRows = WrapRow(data, row, widths);

            // Draw each wrapped line
            foreach (string[] wrappedLine in wrappedRows)
            {
                Console.ForegroundColor = ColorScheme.TableBorder;
                Console.Write(BorderStyle.Vertical);

                for (int col = 0; col < columnCount; col++)
                {
                    Console.ForegroundColor = ColorScheme.TableData;
                    string cellContent = col < wrappedLine.Length ? wrappedLine[col] : "";
                    Console.Write(PadCell(cellContent, widths[col]));

                    Console.ForegroundColor = ColorScheme.TableBorder;
                    Console.Write(BorderStyle.Vertical);
                }

                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
    
    private static List<string[]> WrapRow(string[,] data, int row, int[] widths)
    {
        int columnCount = data.GetLength(1);
        List<string[]> wrappedLines = [];

        // Split each cell into lines based on column width
        List<string>[] cellLines = new List<string>[columnCount];
        int maxLines = 1;

        for (int col = 0; col < columnCount; col++)
        {
            string cellValue = data[row, col];
            int maxWidth = widths[col] - 2; // Remove padding space

            cellLines[col] = WrapText(cellValue, maxWidth);
            maxLines = Math.Max(maxLines, cellLines[col].Count);
        }

        // Create wrapped rows
        for (int line = 0; line < maxLines; line++)
        {
            string[] wrappedLine = new string[columnCount];
            for (int col = 0; col < columnCount; col++)
            {
                wrappedLine[col] = line < cellLines[col].Count ? cellLines[col][line] : "";
            }
            wrappedLines.Add(wrappedLine);
        }

        return wrappedLines;
    }

    // Wrap text to fit within a specified width
    private static List<string> WrapText(string text, int maxWidth)
    {
        List<string> lines = [];

        if (string.IsNullOrEmpty(text))
        {
            lines.Add("");
            return lines;
        }

        if (text.Length <= maxWidth)
        {
            lines.Add(text);
            return lines;
        }

        // Split by spaces and wrap
        string[] words = text.Split(' ');
        string currentLine = "";

        foreach (string word in words)
        {
            if (string.IsNullOrEmpty(currentLine))
            {
                currentLine = word;
            }
            else if ((currentLine + " " + word).Length <= maxWidth)
            {
                currentLine += " " + word;
            }
            else
            {
                lines.Add(currentLine);
                currentLine = word;
            }
        }

        if (!string.IsNullOrEmpty(currentLine))
        {
            lines.Add(currentLine);
        }

        return lines;
    }

    private static void DrawBottomBorder(int[] widths)
    {
        Console.ForegroundColor = ColorScheme.TableBorder;
        Console.Write(BorderStyle.BottomLeft);

        for (int i = 0; i < widths.Length; i++)
        {
            Console.Write(new string(BorderStyle.Horizontal, widths[i]));
            
            if (i < widths.Length - 1)
                Console.Write(BorderStyle.TeeBottom);
        }

        Console.WriteLine(BorderStyle.BottomRight);
        Console.ResetColor();
    }
    
    private static string PadCell(string? content, int width)
    {
        content ??= "";

        if (content.Length >= width)
            return content[..width];

        // Align to left if content is shorter than the column width
        return " " + content.PadRight(width - 1);
    }
}
