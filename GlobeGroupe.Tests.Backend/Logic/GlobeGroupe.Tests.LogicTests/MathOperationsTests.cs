using System.Numerics;

namespace GlobeGroupe.Tests.LogicTests;

[TestClass]
[TestCategory(nameof(MathOperations))]
public class MathOperationsTests
{
    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(1, 1)]
    [DataRow(2, 2)]
    [DataRow(3, 6)]
    [DataRow(4, 24)]
    [DataRow(5, 120)]
    [DataRow(10, 3628800)]
    public void GetFactorial_ReturnsCorrectResult(int n, int expected)
    {
        // Arrange

        // Act
        BigInteger result = MathOperations.GetFactorial(n);

        // Assert
        result.Should().Be(expected);
    }
}
