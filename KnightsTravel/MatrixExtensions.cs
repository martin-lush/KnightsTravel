namespace KnightsTravel
{
    public static class MatrixExtensions
    {
        public static int GetTotalRows(this int[,] matrix)
        {
            return matrix.GetLength(0);
        }

        public static int GetTotalColumns(this int[,] matrix)
        {
            return matrix.GetLength(1);
        }
    }
}
