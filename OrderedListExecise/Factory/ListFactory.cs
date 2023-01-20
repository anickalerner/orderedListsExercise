namespace OrderedListNovidea;
public class ListFactory{

    Random random = new Random();
    /*
    * A default implementation of OrderedList.
    * The list is populated with integers
    */
    public virtual void PopulateList(OrderedList list, int size){
        for (int i = 0; i < size; i++)
        {
            list.Push(GetRandomInt(0, 30));
        }
    }

    public int GetRandomInt(int from, int to){
        return random.Next(from, to);
    }   

}
