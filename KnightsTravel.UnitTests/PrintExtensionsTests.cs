using NUnit.Framework;
using System.Linq;

namespace KnightsTravel.UnitTests
{
    [TestFixture]
    public class PrintExtensionsTests
    {
        [TestCase(1, 1, "\t")] // minimum bounds test
        [TestCase(3, 4, "\t")] // asymmetric test
        [TestCase(4, 3, "\t")] // asymmetric test
        [TestCase(8, 8, "\t")] // actual chess board
        [TestCase(byte.MaxValue, byte.MaxValue, "\t")] // realistic upper bounds test
        public void PrettyPrintToLines_Generates_Expected_Output(int rows, int columns, string delimiter)
        {
            var matrix = InitializationHelper.InitializeSolutionMatrix(rows, columns);

            var expectedLineOutput = string.Join(delimiter, Enumerable.Range(0, matrix.GetTotalColumns()).Select(r => { return $"{Settings.POSITION_NOT_YET_VISITED}"; }));

            var actualOutput = matrix.PrettyPrintToLines(delimiter);

            foreach (var line in actualOutput)
            {
                Assert.AreEqual(expectedLineOutput, line);
            }
        }
    }
}