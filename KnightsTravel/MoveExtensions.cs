namespace KnightsTravel
{
    public static class MoveExtensions
    {
        public static bool CanMoveToPosition(this int[,] matrix, int row, int column)
        {
            var totalRows = matrix.GetTotalRows();
            var totalColumns = matrix.GetTotalColumns();

            return row >= 0 && row < totalRows
                    && column >= 0 && column < totalColumns
                    && matrix[row, column] == Settings.POSITION_NOT_YET_VISITED;
        }
    }
}
