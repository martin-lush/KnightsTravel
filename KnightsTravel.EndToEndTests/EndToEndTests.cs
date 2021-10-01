using NUnit.Framework;
using System;

namespace KnightsTravel.EndToEndTests
{
    [TestFixture]
    public class EndToEndTests
    {
        [TestCase(1, 1)] // special case - it is the opening move
        [TestCase(3, 4)] // postive asymmetric test (a landscape board)
        [TestCase(4, 3)] // postive asymmetric test (a portrait board)
        [TestCase(8, 8)] // actual chess board
        public void SolveKnightsTravel_When_Solveable_Should_Return_Solution(byte totalRows, byte totalColumns)
        {
            var actualResult = Program.SolveKnightsTravel(totalRows, totalColumns, Settings.STARTING_ROW, Settings.STARTING_COLUMN, Settings.PERMISSABLE_MOVES);

            Assert.That(actualResult, Is.Not.Null);
        }

        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(2, 4)] // negative asymmetric test (a landscape board)
        [TestCase(4, 2)] // negative asymmetric test (a portrait board)
        public void SolveKnightsTravel_When_Unsolveable_Should_Return_Null(byte totalRows, byte totalColumns)
        {
            var actualResult = Program.SolveKnightsTravel(totalRows, totalColumns, Settings.STARTING_ROW, Settings.STARTING_COLUMN, Settings.PERMISSABLE_MOVES);

            Assert.That(actualResult, Is.Null);
        }

        [Test]
        public void SolveKnightsTravel_When_Zero_Rows_Throws_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { Program.SolveKnightsTravel(0, 1, Settings.STARTING_ROW, Settings.STARTING_COLUMN, Settings.PERMISSABLE_MOVES); });

            Assert.That(ex.ParamName, Is.EqualTo("rows"));
        }

        [Test]
        public void SolveKnightsTravel_When_Zero_Columns_Throws_ArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(
              delegate { Program.SolveKnightsTravel(1, 0, Settings.STARTING_ROW, Settings.STARTING_COLUMN, Settings.PERMISSABLE_MOVES); });

            Assert.That(ex.ParamName, Is.EqualTo("columns"));
        }
    }
}