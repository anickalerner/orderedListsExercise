namespace OrderedListNovidea;
/// <summary>
/// Class <LinkedList> is an abstract representation of a LinkedList structure
/// </summary>
abstract public class LinkedList{
    public LinkedListNode? Head;

    /// <summary>
    /// Method <Push> adds an item to the beginning of the list.
    /// The new head item points to the rest of the list
    /// </summary>
    public virtual void Push(IComparable node){
        LinkedListNode newNode = new LinkedListNode(node);
        newNode.Next = Head;
        Head = newNode;
    }

    /// <summary>
    /// Method <Pop> removes an item from the beginning of the list.
    /// The item that head pointed to becomes a new head
    /// </summary>
    public virtual IComparable? Pop(){
        if (Head == null)
            return null;
        IComparable node = Head.Node;
        Head = Head.Next;
        return node;
    }

    /// <summary>
    /// Method <Print> prints the list from head to the end of the list
    /// </summary>
    public void Print(){
        LinkedListNode? iterator = Head;
        while (iterator != null)
        {
            System.Console.WriteLine(iterator.ToString());
            iterator = iterator.Next;
        }
    }
    /// <summary>
    /// Method <PopAllAndPrint> pops all the items 
    /// and prints them to the console one by one
    /// </summary>
    public void PopAllAndPrint(){
        while (Head != null){
            System.Console.WriteLine(Pop());
        }
    }
    /// <summary>
    /// Method <PopAll> pops all the items from the list
    /// </summary>
    public void PopAll(){
        while (Head != null){
            Pop();
        }
    }

    /// <summary>
    /// Method <GetNodeType> returns the type of the object that is stored in the list item node
    /// </summary>
    public string? GetNodeType(){
        if (Head == null) return null;
        return Head.Node.GetType().ToString();
    }

}