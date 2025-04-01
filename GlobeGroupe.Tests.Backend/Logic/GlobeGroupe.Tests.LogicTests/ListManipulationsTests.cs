namespace GlobeGroupe.Tests.LogicTests;

[TestClass]
[TestCategory(nameof(ListManipulations))]
public class ListManipulationsTests
{
    [TestMethod]
    [DynamicData(nameof(TestData), DynamicDataSourceType.Method)]
    public void CountLessThan_ReturnValidAnswer(int[] sortedArray, int lessThan, int expected)
    {
        // Arrange

        // Act
        int countLessThan = ListManipulations.CountLessThan(sortedArray, lessThan);

        // Assert
        countLessThan.Should().Be(expected);
    }

    [TestMethod]
    [Timeout(10000)]
    [DataRow(int.MinValue, 0)]
    [DataRow(int.MaxValue, 2_000_000_000)]
    public void CountLessThan_PerformanceTest(int lessThan, int expected)
    {
        // Arrange
        int[] tab = Enumerable.Range(0, 2_000_000_000).ToArray();

        // Act
        int countLessThan = ListManipulations.CountLessThan(tab, lessThan);

        // Assert
        countLessThan.Should().Be(expected);
    }

    #region TestData

    public static IEnumerable<object[]> TestData()
    {
        yield return [new[] { 1, 2, 3, 4, 5 }, 3, 2];
        yield return [new[] { 1, 2, 3, 4, 5 }, 6, 5];
        yield return [new[] { 1, 2, 3, 4, 5 }, 0, 0];
        yield return [new[] { 10, 20, 30, 40, 50 }, 25, 2];
        yield return [new[] { 10, 20, 30, 40, 50 }, 10, 0];
        yield return [new[] { 10, 20, 30, 40, 50 }, 50, 4];
        yield return [new[] { 1, 3, 5, 7, 9 }, 8, 4];
        yield return [new[] { 1, 3, 5, 7, 9 }, 1, 0];
        yield return [new[] { -10, -5, 0, 5, 10 }, 0, 2];
        yield return [new[] { int.MinValue, -1, 0, 1, int.MaxValue }, 1, 3];
        yield return [new int[] { }, 1, 0];
    }

    #endregion /* !TestData */
}
