using System;

namespace KnightsTravel
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class Settings
    {
        // Breif mentioned Chess Board.
        // Normally would have these as private consts and use public static readonly default values
        public const byte CHESS_BOARD_ROWS = 8;
        public const byte CHESS_BOARD_COLUMNS = 8;

        public static readonly Tuple<int, int>[] PERMISSABLE_MOVES = new Tuple<int, int>[8]
        {
            new ( 2,  1),
            new ( 1,  2),
            new (-1,  2),
            new (-2,  1),
            new (-2, -1),
            new (-1, -2),
            new ( 1, -2),
            new ( 2, -1)
        };

        // Force starting values
        public const byte STARTING_ROW = 0;
        public const byte STARTING_COLUMN = 0;
        public const sbyte POSITION_NOT_YET_VISITED = -1;
    }
}
