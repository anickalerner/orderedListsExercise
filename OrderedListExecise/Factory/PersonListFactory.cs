namespace OrderedListNovidea;
public class PersonListFactory: ListFactory{

    public override void PopulateList(OrderedList list, int size){
        for (int i = 0; i < size; i++)
        {
            list.Push(new Person("", "", GetRandomInt(DateTime.Now.Year - 120, DateTime.Now.Year)));
        }
    }    
}
