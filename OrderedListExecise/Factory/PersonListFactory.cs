namespace OrderedListNovidea;
/// <summary>
/// Class <PersonListFactory> populates OrderedList with Person objects.
/// It mainly serves testing purposes
/// </summary>
public class PersonListFactory: ListFactory{
    //private readonly object factoryLock = new object();
    public override void PopulateList(OrderedList list, int size){
        lock(factoryLock){
            for (int i = 0; i < size; i++)
            {
                list.Push(new Person("", "", GetRandomInt(DateTime.Now.Year - 120, DateTime.Now.Year)));
            }
        }
    }    
}
