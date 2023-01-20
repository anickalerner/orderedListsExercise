namespace OrderedListNovidea;
/// <summary>
/// Class <QuickPopOrderedList> extends OrderedList by having a list sorted after every PUSH
/// Its POP method inherits from the base class
/// </summary>
public class QuickPopOrderedList: OrderedList{
    public QuickPopOrderedList():base("QuickPop"){}

    /// <summary>
    /// Method <Push> calls a base Push and then orders the list 
    /// </summary>    
    public override void Push(IComparable node){
        base.Push(node);
        Head = base.mergeSort(Head);
    }
}