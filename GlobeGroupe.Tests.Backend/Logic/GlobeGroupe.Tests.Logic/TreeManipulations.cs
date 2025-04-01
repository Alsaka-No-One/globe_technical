namespace GlobeGroupe.Tests.Logic;

public static class TreeManipulations
{
    /// <summary>
    /// Builds a tree structure from a list of nodes.
    /// 
    /// The method takes a list of nodes, each with an Id and a ParentId, and constructs a tree where each node's children are correctly assigned.
    /// The root node is identified by having a ParentId of 0 or null.
    /// 
    /// The method should handle the following cases:
    /// - Nodes with valid parent-child relationships.
    /// - Nodes with a ParentId that does not correspond to any existing node (these nodes should be ignored or handled gracefully).
    /// - The resulting tree should have a single root node.
    /// 
    /// Example:
    /// Input:
    /// [
    ///     { Id = 1, ParentId = 0 },
    ///     { Id = 2, ParentId = 1 },
    ///     { Id = 3, ParentId = 1 },
    ///     { Id = 4, ParentId = 2 },
    ///     { Id = 5, ParentId = 2 }
    /// ]
    /// 
    /// Output:
    /// Node with Id = 1
    /// ├── Node with Id = 2
    /// │   ├── Node with Id = 4
    /// │   └── Node with Id = 5
    /// └── Node with Id = 3
    /// 
    /// </summary>
    /// <param name="nodes">The list of nodes to build the tree from.</param>
    /// <returns>The root node of the constructed tree.</returns>
    public static Node? BuildTree(List<Node> nodes)
    {
        if (nodes == null || nodes.Count == 0)
        {
            return null;
        }

        Node root = null;
        var nodeDict = nodes.ToDictionary(n => n.Id, n => n);

        foreach (var node in nodes)
        {
            if (node.ParentId == null || node.ParentId == 0)
            {
                root = node;
            } 
            else if (nodeDict.ContainsKey(node.ParentId.Value))
            {
                var parent = nodeDict[node.ParentId.Value];

                if (parent.Children == null)
                {
                    parent.Children = new List<Node>();
                }

                parent.Children.Add(node);
            }
        }
        return root;
    }
}

public class Node
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public List<Node> Children { get; set; }
}
