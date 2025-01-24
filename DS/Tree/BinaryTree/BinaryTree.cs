namespace BinaryTree;
/// <summary>
/// Represents a binary tree, with nodes that store data of <typeparamref name="T"/> type.
/// </summary>
/// <typeparam name="T">Any type that implement <see cref="IComparable"/>.</typeparam>
public struct BinaryTree<T> where T : IComparable<T>
{
    private class Node<TNode> where TNode : IComparable<TNode>
    {
        internal Node<TNode>? Left { get; set; }
        internal Node<TNode>? Right {get; set;}
        internal required TNode Data { get; set; }
    }
    private Node<T>? _root;
    /// <summary>
    /// The amount of nodes the tree currently has.
    /// </summary>
    public int Count => _root == null ? 0 : _Count(_root);
    /// <summary>
    /// The height of the biggest branch of the tree.
    /// </summary>
    public int Height => _root == null ? 0 : _Height(_root);
    /// <summary>
    /// Adds a node to the tree. 
    /// </summary>
    /// <param name="value">Value to be stored in the node.</param>
    public void Add(T value)
    {
        Node<T> newNode = new()
        {
            Data = value,
        };
        if (_root == null)
        {
            _root = newNode;
            return;
        }
        var current = _root;
        Node<T>? previous = null;
        var bigger = false;
        while (current != null)
        {
            previous = current;
            switch (newNode.Data.CompareTo(current.Data))
            {
                case > 0:
                    bigger = true;
                    current = current.Right;
                    break;
                case < 0:
                    bigger = false;
                    current = current.Left;
                    break;
                case 0:
                    Console.WriteLine("Node already exists");
                    return;
            }
        }
        if (bigger) previous!.Right = newNode;
        else previous!.Left = newNode;
    }
    /// <summary>
    /// Prints the tree into the terminal.
    /// </summary>
    public void Print()
    {
        if (_root == null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }
        Print(_root);
    }
    private static void Print(Node<T>? node, string indent = "")
    {
        if (node is null) return;
        Print(node.Left, indent + " ");
        Console.WriteLine($"{indent}{node.Data}");
        Print(node.Right, indent + " ");
    }

    private static int _Height(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(_Height(node.Left), _Height(node.Right));
    }
    private static int _Count(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + _Count(node.Left) + _Count(node.Right);
    }
}