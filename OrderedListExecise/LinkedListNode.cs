namespace OrderedListNovidea;
public class LinkedListNode: IComparable{
    public IComparable Node;
    public LinkedListNode Next;

    public LinkedListNode(IComparable node){
        Node = node;
        Next = null;
    }

    public override string ToString(){
        return Node.ToString();
    }

    public int CompareTo(object incomingObj){
        LinkedListNode incomingNode = incomingObj as LinkedListNode;
        return Node.CompareTo(incomingNode.Node);
    }

}