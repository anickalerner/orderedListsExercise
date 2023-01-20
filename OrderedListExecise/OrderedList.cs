namespace OrderedListNovidea;
/// <summary>
/// Class <OrderedList> extends LinkedList by sorting behaviour
/// The list will be sorted by Merge Sort algorithm
/// </summary>

public class OrderedList: LinkedList{
    public string Name;

    public OrderedList(string name):base(){
        Name = name;
    }

    public LinkedListNode? mergeSort(LinkedListNode head){
        // Base case : if head is null
        if (head == null || head.Next == null) {
            return head;
        }
  
        // get the middle of the list
        LinkedListNode? middle = getMiddle(head);
        LinkedListNode? nextofmiddle = middle?.Next;
  
        // set the next of middle node to null
        middle.Next = null;
  
        // Apply mergeSort on left list
        LinkedListNode? left = mergeSort(head);
  
        // Apply mergeSort on right list
        LinkedListNode? right = mergeSort(nextofmiddle);
  
        // Merge the left and right lists
        LinkedListNode? sortedlist = sortedMerge(left, right);
        return sortedlist;
    }

    LinkedListNode? getMiddle(LinkedListNode head){
        // Base case
        if (head == null)
            return head;
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

    LinkedListNode? sortedMerge(LinkedListNode a, LinkedListNode b){
        LinkedListNode? result = null;
        /* Base cases */
        if (a == null)
            return b;
        if (b == null)
            return a;
  
        /* Pick either a or b, and recur */
        if (a.CompareTo(b) < 0) {
            result = a;
            result.Next = sortedMerge(a.Next, b);
        }
        else {
            result = b;
            result.Next = sortedMerge(a, b.Next);
        }
        return result;
    }
}