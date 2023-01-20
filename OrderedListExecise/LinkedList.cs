namespace OrderedListNovidea;
abstract public class LinkedList{
    public LinkedListNode? Head;

    public virtual void Push(IComparable node){
        LinkedListNode newNode = new LinkedListNode(node);
        newNode.Next = Head;
        Head = newNode;
    }

    public virtual IComparable? Pop(){
        if (Head == null)
            return null;
        IComparable node = Head.Node;
        Head = Head.Next;
        return node;
    }

    public void Print(){
        LinkedListNode? iterator = Head;
        while (iterator != null)
        {
            System.Console.WriteLine(iterator.ToString());
            iterator = iterator.Next;
        }
    }

    public void PopAllAndPrint(){
        while (Head != null){
            System.Console.WriteLine(Pop());
        }
    }

    public void PopAll(){
        while (Head != null){
            Pop();
        }
    }

    public string? GetNodeType(){
        if (Head == null) return null;
        return Head.Node.GetType().ToString();
    }

}