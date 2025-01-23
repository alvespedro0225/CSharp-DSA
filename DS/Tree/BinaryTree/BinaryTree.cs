namespace BinaryTree;

public struct BinaryTree<T> where T : IComparable<T>
{
    internal class Node<TNode> where TNode : IComparable<TNode>
    {
        internal Node<TNode>? Left;
        internal Node<TNode>? Right;
        internal required TNode Data;
    }
    private Node<T>? _root;

    public int Size => _root == null ? 0 : _Size(_root);
    public int Height => _root == null ? 0 : _Height(_root);

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
        Console.WriteLine($"{indent}{node.Data}");
        Print(node.Left, indent + " ");
        Print(node.Right, indent + " ");
    }

    private static int _Height(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(_Height(node.Left), _Height(node.Right));
    }
    private static int _Size(Node<T>? node)
    {
        if (node == null) return 0;
        return 1 + _Size(node.Left) + _Size(node.Right);
    }
}