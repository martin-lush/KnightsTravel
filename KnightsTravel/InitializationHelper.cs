using System;

namespace KnightsTravel
{
    public static class InitializationHelper
    {
#if UNSAFE
        public static unsafe int[,] InitializeSolutionMatrix(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentException("Must be greater than 0", nameof(rows));
            if (columns <= 0) throw new ArgumentException("Must be greater than 0", nameof(columns));

            var solution = new int[rows, columns];

            // unsafe but an order of magnitude faster with bigger matrices!
            // No need for bounds checking as it is one fixed piece of memory.
            fixed (int* a = &solution[0, 0])
            {
                int* b = a;
                var span = new Span<int>(b, rows * columns);
                span.Fill(Settings.POSITION_NOT_YET_VISITED);
            }

            return solution;
        }
#else
        public static int[,] InitializeSolutionMatrix(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentException("Must be greater than 0", nameof(rows));
            if (columns <= 0) throw new ArgumentException("Must be greater than 0", nameof(columns));

            var solution = new int[rows, columns];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columns; columnIndex++)
                {
                    solution[rowIndex, columnIndex] = Settings.POSITION_NOT_YET_VISITED;
                }
            }

            return solution;
        }
#endif
    }
}
