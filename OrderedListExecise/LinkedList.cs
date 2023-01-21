namespace OrderedListNovidea;
/// <summary>
/// Class <LinkedList> is an abstract representation of a LinkedList structure
/// </summary>
abstract public class LinkedList{
    public LinkedListNode? Head;
    public int Counter = 0;
    private readonly object listLock = new object();
    
    /// <summary>
    /// Method <Push> adds an item to the beginning of the list.
    /// The new head item points to the rest of the list.
    /// Changing the list is lock-protected for multi-threading
    /// </summary>
    public virtual void Push(IComparable node){
        LinkedListNode newNode = new LinkedListNode(node);
        lock(listLock){
            newNode.Next = Head;
            Head = newNode;
            Counter++;
        }
    }

    /// <summary>
    /// Method <Pop> removes an item from the beginning of the list.
    /// The item that head pointed to becomes a new head.
    /// Changing the list is lock-protected for multi-threading
    /// </summary>
    public virtual IComparable? Pop(){
        if (Head == null) return null;
        IComparable? node = null;
        lock(listLock){
            node = Head.Node;
            Head = Head.Next;
            Counter--;
        }
        return node;
    }

    /// <summary>
    /// Method <Print> prints the list from head to the end of the list
    /// </summary>
    public void Print(){
        LinkedListNode? iterator = Head;
        lock(listLock){
            System.Console.WriteLine("/////////////////");
            while (iterator != null)
            {
                System.Console.WriteLine(iterator.ToString());
                iterator = iterator.Next;
            }
            System.Console.WriteLine("/////////////////");
        }
    }

    /// <summary>
    /// Method <PopAllAndPrint> pops all the items 
    /// and prints them to the console one by one
    /// </summary>
    public void PopAllAndPrint(){
        //lock(listLock){
            while (Head != null){
                System.Console.WriteLine(Pop());
            }
        //}
    }

    /// <summary>
    /// Method <PopAll> pops all the items from the list
    /// </summary>
    public void PopAll(){
        lock(listLock){
            while (Head != null){
                Pop();
            }
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