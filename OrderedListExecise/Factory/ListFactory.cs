namespace OrderedListNovidea;
/// <summary>
/// Class <ListFactory> serves as a factory that populates OrderedList with data.
/// It mainly serves testing purposes
/// </summary>
public class ListFactory{

    Random random = new Random();
    /// <summary>
    /// Metohod <PopulateList> is a default population of OrderedList.
    /// The list is populated with integers
    /// </summary>
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
