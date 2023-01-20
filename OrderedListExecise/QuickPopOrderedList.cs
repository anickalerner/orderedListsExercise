namespace OrderedListNovidea;
public class QuickPopOrderedList: OrderedList{

    public QuickPopOrderedList():base("QuickPop"){}
    public override void Push(IComparable node){
        base.Push(node);
        Head = base.mergeSort(Head);
    }
}