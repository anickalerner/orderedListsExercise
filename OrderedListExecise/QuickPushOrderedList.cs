namespace OrderedListNovidea;
/// <summary>
/// Class <QuickPushOrderedList> extends OrderedList by poping items in the ordered fashion
/// Its Push method inherits from the base class
/// </summary>
public class QuickPushOrderedList: OrderedList{
    public QuickPushOrderedList():base("QuickPush"){}

    /// <summary>
    /// Method <Pop> overrides base Pop method by returning the highest node from the list
    /// </summary>    
    public override IComparable? Pop(){
        lock(base.listLock){
            return PopHighestNode();
        }
    }

    /// <summary>
    /// Method <PopHighestNode> pops the highest-value item from the list
    /// </summary>
    public IComparable? PopHighestNode(){
        LinkedListNode? max = Head;
        LinkedListNode? iterator = Head;
        LinkedListNode? beforeMax = null;
        while (iterator != null){
            // If the current max is smaller than the next item, we update the max
            if (max.CompareTo(iterator.Next) < 0){
                beforeMax = iterator;
                max = iterator.Next;
            }
            // We advance in the list
            iterator = iterator.Next;
        }
        // If we didn't advance in the list, the max is at the top of the list
        if (beforeMax == null){
            Head = max.Next;
        }
        // Otherwise we bridge between the item before max and the item after it
        else{
            beforeMax.Next = max.Next;
        }
        Counter--;
        return max.Node;
    }
}