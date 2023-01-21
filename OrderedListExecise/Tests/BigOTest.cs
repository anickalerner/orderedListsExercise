using System.Diagnostics;

namespace OrderedListNovidea;

/// <summary>
/// Class <BigOTest> Tests all List / Operation variations for two different types of objects:
/// DateTime and Person
/// </summary>
public class BigOTest: IRunListTest{

    public void TestLists()
    {
        System.Console.WriteLine("Testing OrderdLists for time complexity.");
        System.Console.WriteLine("The slope for O(1) graph is 0.");

        // Creates LinkedList for objects of type DateTime
        DateListFactory dateFactory = new DateListFactory();
        // Creates LinkedList for objects of type Person
        PersonListFactory personFactory = new PersonListFactory();
        TestFactory(dateFactory);
        TestFactory(personFactory);
    }

    /// <summary>
    /// Creates two types of OrderedList objects for a given factory:
    /// QuickPushOrderedList and QuickPopOrderedList
    /// </summary>
    public void TestFactory(ListFactory factory)
    {
        TestOrderedList(factory, new QuickPushOrderedList().GetType().ToString());
        TestOrderedList(factory, new QuickPopOrderedList().GetType().ToString());
    }

    /// <summary>
    /// Runs two types of tests on a given OrderedList object: Push and Pop
    /// </summary>
    public void TestOrderedList(ListFactory factory, string listType)
    {
        Random random = new Random();
        TestBigO(factory, listType, random.Next(300, 800), "push");
        TestBigO(factory, listType, random.Next(300, 800), "pop");         
    }

    /// <summary>
    /// Runs time tests on Push or Pop operations
    /// of QuickPushOrderedList or QuickPopOrderedList
    /// </summary>
    public void TestBigO(ListFactory factory, string listType, int iterations, string operation)
    {
        Stopwatch stopWatch = new Stopwatch();
        long[] results = new long [iterations];
        string? listNodeObjectType = null;
        for (int i = 0; i < results.Length; i++)
        {
            OrderedList? list = GetOrderedListByType(listType);
            if (list == null) return;
            if (operation == "push"){
                stopWatch.Start();
                factory.PopulateList(list, i);
                stopWatch.Stop();
            }
            else if (operation == "pop"){
                if (list.Head == null){
                    factory.PopulateList(list, i);
                }
                stopWatch.Start();
                list.PopAll();
                stopWatch.Stop();
            }
            // Get type name of the objects in the list node
            if (listNodeObjectType == null){
                listNodeObjectType = list?.GetNodeType();
            }
            // We take times from Stopwatch and save them in the results array
            // Index of the results array is list's size
            // The value of results[i] is the time that the procedure took
            results[i] = stopWatch.ElapsedMilliseconds;
        }
        System.Console.WriteLine("------------------------------");
        System.Console.WriteLine($"Testing {listType} {operation.ToUpper()} with nodes of type {listNodeObjectType}");
        System.Console.WriteLine($"Run {results.Length} tests on input sizes from 0 to {results.Length} ");
        System.Console.WriteLine($"The slope of QuickPushOrderedList {operation.ToUpper()} is {GetResultsSlope(results)}");
    }

    ///<summary>
    /// Creates Quick-x-OrderedList by type
    ///</summary>
    public OrderedList? GetOrderedListByType(string type)
    {
        if (type.Contains("QuickPushOrderedList")){
            return new QuickPushOrderedList();
        }
        else if (type.Contains("QuickPopOrderedList")){
            return new QuickPopOrderedList();
        }
        else{
            return null;
        }
    }

    ///<summary>
    /// Calculates graph's slope of the given runtime x input size data
    /// Returns average slope
    ///</summary>
    public double GetResultsSlope(long[] runtimes){        
        int [] slopes = new int[runtimes.Length-1 / 2];
        // Compare every two adjacent points of the graph data to calculate graph's slope
        for (int i = 0; i < runtimes.Length-1; i=i+2)
        {
            // (y2 - y1)/(x2 - x1)
            slopes[i/2] = Convert.ToInt32((runtimes[i] - runtimes[i+1]));
        }
        return slopes.Average();
    }

}