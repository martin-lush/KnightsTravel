using System;
using System.Collections.Generic;
using System.Text;

namespace KnightsTravel
{
    public static class PrintExtensions
    {
        public static IEnumerable<string> PrettyPrintToLines(this int[,] matrix, string delimiter = "\t")
        {
            var totalRows = matrix.GetTotalRows();
            var totalColumns = matrix.GetTotalColumns();

            var lines = new List<string>(totalRows);

            for (var row = 0; row < totalRows; row++)
            {
                var sb = new StringBuilder();
                for (var column = 0; column < totalColumns; column++)
                {
                    sb.Append(matrix[row, column]).Append(delimiter);
                }

                // Note: This looks messy but saves an 'is last index' check per loop iteration
                var lineOutput = sb.ToString();
                var trimmedOutput = lineOutput.Remove(lineOutput.LastIndexOf(delimiter, StringComparison.Ordinal));
                lines.Add(trimmedOutput);
            }

            return lines;
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void PrintToConsole(this int[,] matrix, string delimiter = "\t")
        {
            foreach (var line in matrix.PrettyPrintToLines(delimiter))
            {
                Console.WriteLine(line);
            }
        }
    }
}
