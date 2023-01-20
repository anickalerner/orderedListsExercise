namespace OrderedListNovidea;
public class DateListFactory: ListFactory{

    public override void PopulateList(OrderedList list, int size){
        for (int i = 0; i < size; i++)
        {
            list.Push(DateTime.Now.AddDays(GetRandomInt(0, 30)));
        }
    }
    
}
