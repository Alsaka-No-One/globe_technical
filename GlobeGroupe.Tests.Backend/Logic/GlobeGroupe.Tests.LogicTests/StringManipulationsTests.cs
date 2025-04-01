namespace GlobeGroupe.Tests.LogicTests;

[TestClass]
[TestCategory(nameof(StringManipulations))]
public class StringManipulationsTests
{
    [TestMethod]
    [DataRow("hello", "olleh")]
    [DataRow("world", "dlrow")]
    [DataRow("", "")]
    public void ReverseString_ReturnsReversedString(string input, string expected)
    {
        // Arrange

        // Act
        string result = StringManipulations.Reverse(input);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("hello world", "Hello World")]
    [DataRow("c# programming", "C# Programming")]
    [DataRow("", "")]
    [DataRow("strange wOrd", "Strange WOrd")]
    public void CapitalizeWords_ReturnsCapitalizedWords(string input, string expected)
    {
        // Arrange

        // Act
        string result = StringManipulations.CapitalizeWords(input);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    [DataRow("racecar", true)]
    [DataRow("hello", false)]
    [DataRow("A man a plan a canal Panama", true)]
    [DataRow("", true)]
    public void IsPalindrome_ReturnsCorrectResult(string input, bool expected)
    {
        // Arrange

        // Act
        bool result = StringManipulations.IsPalindrome(input);

        // Assert
        result.Should().Be(expected);
    }
}
