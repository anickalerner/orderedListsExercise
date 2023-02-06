namespace OrderedListNovidea;
/// <summary>
/// Class <QuickPopOrderedList> extends OrderedList by pushing a node to the right place in the list,
/// keeping a list ordered.
/// Its POP method inherits from the base class
/// </summary>
public class QuickPopOrderedList: OrderedList{
    public QuickPopOrderedList():base("QuickPop"){}

    /// <summary>
    /// Method <Push> overrides the base Push method by inserting a node to the correct place in the list  
    /// </summary>    
    public override void Push(IComparable node){
        lock(base.listLock){
            PushByOrder(node);
        }
    }

    /// <summary>
    /// Method <PushByOrder> adds an item to the list in the descending order
    /// </summary>
    public void PushByOrder(IComparable node){
        LinkedListNode newNode = new LinkedListNode(node);
        LinkedListNode? iterator = Head;
        // In case this is a new list or item is bigger than the Head
        if (Head == null || newNode.CompareTo(Head) > 0){
            newNode.Next = Head;
            Head = newNode;            
            Counter++;
            return;
        }
        // We attempt to reduce run cycles by checking if an item might be in the lower half of the list
        iterator = FindStart(Head, newNode);        
        while (iterator != null){
            // If the item is bigger than the current item
            if (iterator.Next == null || newNode.CompareTo(iterator.Next) > 0){
                // The item is inserted before the first item that is smaller than the new item
                // The previous, bigger, item is linked to the new item
                newNode.Next = iterator.Next;
                iterator.Next = newNode;
                Counter++;
                return;
            }
            // If the item is smaller that the current item, we advance in the list
            else{
                iterator = iterator.Next;
            }
        }
    }

    /// <summary>
    /// Method <FindStart> recursively partitions a list in half and checks if the item might belong to the lower part of the OrderedList
    /// </summary>
    public LinkedListNode FindStart(LinkedListNode head, LinkedListNode newNode){
        LinkedListNode middle = GetMiddle(head);
        if (newNode.CompareTo(middle.Next) < 0){
            return FindStart(middle.Next, newNode);
        }
        else return head;
    }

    /// <summary>
    /// Method <GetMiddle> returns a middle item of the list starting from a <head> item
    /// </summary>
    LinkedListNode? GetMiddle(LinkedListNode head){
        if (head == null){
            return head;
        }
        LinkedListNode fastptr = head.Next;
        LinkedListNode slowptr = head;
  
        // Move fastptr by two and slow ptr by one
        // Finally slowptr will point to middle node
        while (fastptr != null) {
            fastptr = fastptr.Next;
            if (fastptr != null) {
                slowptr = slowptr.Next;
                fastptr = fastptr.Next;
            }
        }
        return slowptr;
    }

}