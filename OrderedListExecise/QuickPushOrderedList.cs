namespace OrderedListNovidea;
 public class QuickPushOrderedList: OrderedList{

    public QuickPushOrderedList():base("QuickPush"){}

    public override IComparable Pop(){
        Head = base.mergeSort(Head);
        return base.Pop();
    }
 }