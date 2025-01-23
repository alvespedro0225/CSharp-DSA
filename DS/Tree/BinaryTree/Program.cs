var tree = new BinaryTree<int>();
var random = new Random();
for (var i = 0; i < 5; i++)
{
    tree.Add(random.Next(0, 1000));
}
tree.Print();


public struct BinaryTree<T> where T : IComparable<T>
{
    internal class Node<TNode> where TNode : IComparable<TNode>
    {
        internal Node<TNode>? Left;
        internal Node<TNode>? Right;
        internal TNode? Value;
    }

    private Node<T>? _root;
    private int _size;

    public void Add(T value)
    {
        Node<T> newNode = new()
        {
            Value = value,
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
            switch (newNode.Value.CompareTo(current.Value))
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
        _size++;
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
        Print(node.Left, indent + "|");
        Print(node.Right, indent + "|");
        Console.WriteLine($"{indent}{node.Value}");
    }
}