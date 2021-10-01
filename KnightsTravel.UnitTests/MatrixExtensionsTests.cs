using NUnit.Framework;

namespace KnightsTravel.UnitTests
{
    [TestFixture]
    public class MatrixExtensionsTests
    {
        [TestCase(1, 1)] // minimum bounds test
        [TestCase(3, 4)] // asymmetric test
        [TestCase(4, 3)] // asymmetric test
        [TestCase(8, 8)] // actual chess board
        [TestCase(byte.MaxValue, byte.MaxValue)] // realistic upper bounds test
        public void GetTotalRows_Returns_Expected_Result(int rows, int columns)
        {
            var matrix = InitializationHelper.InitializeSolutionMatrix(rows, columns);

            var actualTotalRows = matrix.GetTotalRows();

            Assert.That(actualTotalRows, Is.EqualTo(rows));
        }

        [TestCase(1, 1)] // minimum bounds test
        [TestCase(3, 4)] // asymmetric test
        [TestCase(4, 3)] // asymmetric test
        [TestCase(8, 8)] // actual chess board
        [TestCase(byte.MaxValue, byte.MaxValue)] // realistic upper bounds test
        public void GetTotalColumns_Returns_Expected_Result(int rows, int columns)
        {
            var matrix = InitializationHelper.InitializeSolutionMatrix(rows, columns);

            var actualTotalColumns = matrix.GetTotalColumns();

            Assert.That(actualTotalColumns, Is.EqualTo(columns));
        }
    }
}