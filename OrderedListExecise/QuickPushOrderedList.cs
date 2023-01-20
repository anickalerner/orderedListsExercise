namespace OrderedListNovidea;
/// <summary>
/// Class <QuickPushOrderedList> extends OrderedList by having a list sorted before every POP
/// Its Push method inherits from the base class
/// </summary>
public class QuickPushOrderedList: OrderedList{
    public QuickPushOrderedList():base("QuickPush"){}

    /// <summary>
    /// Method <Pop> orders the list and then calls a base Pop method
    /// </summary>    
    public override IComparable Pop(){
        Head = base.mergeSort(Head);
        return base.Pop();
    }
}