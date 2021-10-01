using NUnit.Framework;

namespace KnightsTravel.UnitTests
{
    [TestFixture]
    public class MoveExtensionsTests
    {
        private const int TOTAL_ROWS = 8;
        private const int TOTAL_COLUMNS = 8;

        private int[,] Matrix;

        [SetUp]
        public void Setup()
        {
            Matrix = InitializationHelper.InitializeSolutionMatrix(TOTAL_ROWS, TOTAL_COLUMNS);
        }

        [Test]
        public void CanMoveToPosition_When_Not_Visited_Returns_True()
        {
            Matrix[0, 0] = Settings.POSITION_NOT_YET_VISITED;

            var actualResult = Matrix.CanMoveToPosition(0, 0);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void CanMoveToPosition_When_Previously_Visited_Returns_False()
        {
            Matrix[0, 0] = Settings.POSITION_NOT_YET_VISITED + 1;

            var actualResult = Matrix.CanMoveToPosition(0, 0);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CanMoveToPosition_When_Column_Outside_Matrix_Returns_False()
        {
            var actualResult = Matrix.CanMoveToPosition(0, TOTAL_COLUMNS + 1);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void CanMoveToPosition_When_Row_Outside_Matrix_Returns_False()
        {
            var actualResult = Matrix.CanMoveToPosition(TOTAL_ROWS + 1, 0);

            Assert.IsFalse(actualResult);
        }
    }
}