namespace OrderedListNovidea;
/// <summary>
/// Class <LinkedListNode> represents an item of the LinkedList
/// Implements IComparable interface that allows sorting list items
/// </summary>
public class LinkedListNode: IComparable{
    // Node stores a data object
    public IComparable Node;
    // Next is a pointer to the next item in the LinkedList
    public LinkedListNode? Next;

    public LinkedListNode(IComparable node){
        Node = node;
        Next = null;
    }

    public override string? ToString() => Node.ToString();

    /// <summary>
    /// Method <CompareTo> delegates comparing nodes to the types of the node data objects
    /// </summary>
    public int CompareTo(object? incomingObj){
        LinkedListNode? incomingNode = incomingObj as LinkedListNode;
        return Node.CompareTo(incomingNode?.Node);
    }

}