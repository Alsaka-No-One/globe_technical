namespace GlobeGroupe.Tests.LogicTests;

[TestClass]
[TestCategory(nameof(TreeManipulations))]
public class TreeManipulationsTests
{
    [TestMethod]
    [DynamicData(nameof(GetNodeConfigurations), DynamicDataSourceType.Method)]
    public void BuildTree_ShouldBuildCorrectTreeStructure(List<Node> nodes, int expectedRootId)
    {
        // Act
        Node root = TreeManipulations.BuildTree(nodes);

        // Assert
        root.Should().NotBeNull();
        root.Id.Should().Be(expectedRootId);
    }

    public static IEnumerable<object[]> GetNodeConfigurations()
    {
        yield return
        [
            new List<Node>
                {
                new() { Id = 1 },
                new() { Id = 2, ParentId = 1 },
                new() { Id = 3, ParentId = 1 },
                new() { Id = 4, ParentId = 1 },
                new() { Id = 5, ParentId = 2 }
                },
                1 // expectedRootId
        ];

        yield return
        [
            new List<Node>
                {
                new() { Id = 10 },
                new() { Id = 20, ParentId = 10 },
                new() { Id = 30, ParentId = 20 },
                new() { Id = 40, ParentId = 20 },
                new() { Id = 50, ParentId = 20 },
                new() { Id = 60, ParentId = 30 }
                },
                10 // expectedRootId
        ];

        yield return
        [
            new List<Node>
                {
                new() { Id = 100 },
                new() { Id = 200, ParentId = 100 },
                new() { Id = 300, ParentId = 200 },
                new() { Id = 400, ParentId = 300 },
                new() { Id = 500, ParentId = 300 },
                new() { Id = 600, ParentId = 300 },
                new() { Id = 700, ParentId = 300 }
                },
                100 // expectedRootId
        ];

        yield return
        [
            new List<Node>
                {
                new() { Id = 1 },
                new() { Id = 2, ParentId = 1 },
                new() { Id = 3, ParentId = 1 },
                new() { Id = 4, ParentId = 6 },
                new() { Id = 5, ParentId = 2 }
                },
                1 // expectedRootId
        ];
    }
}
