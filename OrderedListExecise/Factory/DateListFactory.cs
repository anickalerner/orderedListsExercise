namespace OrderedListNovidea;
/// <summary>
/// Class <DateListFactory> populates OrderedList with DateTime strings.
/// It mainly serves testing purposes
/// </summary>
public class DateListFactory: ListFactory{
    public override void PopulateList(OrderedList list, int size){
        lock(factoryLock){
            for (int i = 0; i < size; i++)
            {
                list.Push(DateTime.Now.AddDays(GetRandomInt(0, 30)));
            }
        }
    }
    
}
