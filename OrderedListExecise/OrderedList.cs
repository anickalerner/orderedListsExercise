namespace OrderedListNovidea;
/// <summary>
/// Class <OrderedList> extends LinkedList 
/// Keeps track of List Name
/// </summary>

public class OrderedList: LinkedList{
    public string Name;

    public OrderedList(string name):base() => Name = name;    
}