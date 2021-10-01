using NUnit.Framework;
using System;
using System.Linq;

namespace KnightsTravel.UnitTests
{
    [TestFixture]
    public class InitializationHelperTests
    {
        [TestCase(1, 1)] // minimum bounds test
        [TestCase(3, 4)] // asymmetric test
        [TestCase(4, 3)] // asymmetric test
        [TestCase(8, 8)] // actual chess board
        [TestCase(byte.MaxValue, byte.MaxValue)] // realistic upper bounds test
        public void InitializeSolutionMatrix_Generates_Expected_Output(int rows, int columns)
        {
            var expectedRow = Enumerable.Range(0, columns).Select(x => Settings.POSITION_NOT_YET_VISITED);

            var actualMatrix = InitializationHelper.InitializeSolutionMatrix(rows, columns);

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var actualRow = Enumerable.Range(0, actualMatrix.GetTotalColumns()).Select(x => actualMatrix[rowIndex, x]);

                CollectionAssert.AreEqual(expectedRow, actualRow);
            }
        }

        [Test]
        public void InitializeSolutionMatrix_Zero_Rows()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { InitializationHelper.InitializeSolutionMatrix(0, 1); });

            Assert.That(ex.ParamName, Is.EqualTo("rows"));
        }

        [Test]
        public void InitializeSolutionMatrix_Negative_Rows()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { InitializationHelper.InitializeSolutionMatrix(-1, 1); });

            Assert.That(ex.ParamName, Is.EqualTo("rows"));
        }

        [Test]
        public void InitializeSolutionMatrix_Zero_Columns_Throws_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { InitializationHelper.InitializeSolutionMatrix(1, 0); });

            Assert.That(ex.ParamName, Is.EqualTo("columns"));
        }

        [Test]
        public void InitializeSolutionMatrix_Negative_Columns_Throws_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { InitializationHelper.InitializeSolutionMatrix(1, -1); });

            Assert.That(ex.ParamName, Is.EqualTo("columns"));
        }
    }
}