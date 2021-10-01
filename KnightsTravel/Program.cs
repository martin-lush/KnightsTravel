using System;

namespace KnightsTravel
{
    public class Program
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        [STAThread]
        public static void Main()
        {
#if ENABLE_APPLICATION_INSIGHTS
            var telemetryClient = ApplicationInsightsHelper.GenerateApplicationInsightsService(Settings.APPLICATION_INSIGHTS_KEY);
#endif

            SolveKnightsTravel(Settings.CHESS_BOARD_ROWS, Settings.CHESS_BOARD_COLUMNS, Settings.STARTING_ROW, Settings.STARTING_COLUMN, Settings.PERMISSABLE_MOVES);
            Console.ReadLine();

#if ENABLE_APPLICATION_INSIGHTS
            telemetryClient.Flush();
#endif
        }

        /// <summary>
        /// Solve the Knight Tour problem using Backtracking strategy.
        /// </summary>
        /// <param name="rows">Total rows the board has (constricted to a maximum of 255)</param>
        /// <param name="columns">Total columns the board has (constricted to a maximum of 255)</param>
        /// <param name="startingRow">The index of the row to start at</param>
        /// <param name="startingColumn">The inded of the column to start at</param>
        /// <param name="permissiableMoves">All permissable moves that the Knight may make</param>
        /// <returns>True if solvable; else false</returns>
        /// <remarks>There may be more than one solution. This function prints one of the feasible solutions.</remarks>
        public static int[,] SolveKnightsTravel(byte rows, byte columns, byte startingRow, byte startingColumn, Tuple<int, int>[] permissiableMoves)
        {
            var solution = InitializationHelper.InitializeSolutionMatrix(rows, columns);

            solution[startingRow, startingColumn] = 0; // starting move

            if (!SolveKnightsTravelRecursive(solution, startingRow, startingColumn, 1, permissiableMoves))
            {
                Console.WriteLine("Solution does not exist");
                return null;
            }
            else
            {
                solution.PrintToConsole();
                return solution;
            }
        }

        private static bool SolveKnightsTravelRecursive(int[,] solution, int row, int column, int moveNumber, Tuple<int, int>[] permissiableMoves)
        {
            if (moveNumber == solution.Length)
                return true;

            // TODO: Think about speeding this up with Parallelism 
            // Try all next moves from the current coordinate
            for (var i = 0; i < permissiableMoves.Length; i++)
            {
                var next_row = row + permissiableMoves[i].Item1;
                var next_column = column + permissiableMoves[i].Item2;

                if (solution.CanMoveToPosition(next_row, next_column))
                {
                    solution[next_row, next_column] = moveNumber;

                    if (SolveKnightsTravelRecursive(solution, next_row, next_column, moveNumber + 1, permissiableMoves))
                    {
                        return true;
                    }
                    else
                    {
                        // Backtracking
                        solution[next_row, next_column] = Settings.POSITION_NOT_YET_VISITED;
                    }
                }
            }

            return false;
        }
    }
}
