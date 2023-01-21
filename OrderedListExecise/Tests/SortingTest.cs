namespace OrderedListNovidea;

/// <summary>
/// Class <SortingTest> tests QuickPushOrderedList and QuickPopOrderedList for sorting
/// </summary>
public class SortingTest: IRunListTest{

    public int ListSize = 10;
    public SortingTest(int size) => ListSize = size;

    ///<summary>
    /// Method <TestLists> in SortingTest Class creates 2 types of OrderedLists 
    /// with 2 types of objects: DateTime and Person, populates each list and runs RunListTest method with each
    ///</summary<
    public void TestLists(){
        DateListFactory dateFactory = new DateListFactory();
        QuickPushOrderedList datePushList = new QuickPushOrderedList();
        QuickPopOrderedList datePopList = new QuickPopOrderedList();

        dateFactory.PopulateList(datePushList, ListSize);
        RunListTest(datePushList);
        
        dateFactory.PopulateList(datePopList, ListSize);
        RunListTest(datePopList);

        PersonListFactory personFactory = new PersonListFactory();
        QuickPushOrderedList personPushList = new QuickPushOrderedList();
        QuickPopOrderedList personPopList = new QuickPopOrderedList();

        personFactory.PopulateList(personPushList, ListSize);        
        RunListTest(personPushList);
        
        personFactory.PopulateList(personPopList, ListSize);        
        RunListTest(personPopList);
    }

    ///<summary>
    /// Method <RunListTest> prints an OrderedList and pops all items from it.
    /// It shows that QuickPushOrderedList is populated without ordering,
    /// while QuickPopOrderedList is ordered while being populated 
    ///</summary>
    public void RunListTest(OrderedList? list){
        System.Console.WriteLine("******************************");
        System.Console.WriteLine($"{list?.Name} list run with {list?.GetNodeType()}");
        System.Console.WriteLine("");
        System.Console.WriteLine($"Newly populated {list?.Name}:");
        System.Console.WriteLine("-----------------------");
        list?.Print();
        
        System.Console.WriteLine("");
        System.Console.WriteLine($"Pop from {list?.Name} list");
        System.Console.WriteLine("-----------------------");
        list?.PopAllAndPrint();
    }

}