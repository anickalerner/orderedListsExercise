using System.Diagnostics;

namespace OrderedListNovidea;

/// <summary>
/// Class <BigOTest> Tests all List / Operation variations for two different types of objects:
/// DateTime and Person
/// </summary>
public class BigOTest: IRunListTest{

    public void TestLists(){
        System.Console.WriteLine("*** Big O Tests ***");        
        System.Console.WriteLine("Testing OrderdLists for time complexity.");
        System.Console.WriteLine("The slope for O(1) graph is 0.");
        System.Console.WriteLine("The slope for O(n) graph is > 0 and constant");

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
        TestBigO(factory, listType, "push");
        TestBigO(factory, listType, "pop");         
    }

    /// <summary>
    /// Runs time tests on Push or Pop operations
    /// of QuickPushOrderedList or QuickPopOrderedList
    /// </summary>
    public void TestBigO(ListFactory factory, string listType, string operation)
    {
        Stopwatch stopWatch = new Stopwatch();
        var results = new List<RuntimeResult>{
            {new RuntimeResult(){InputSize = 100}},
            {new RuntimeResult(){InputSize = 1000}},
            {new RuntimeResult(){InputSize = 10000}},
        };
        string listNodeType = "";
        foreach( RuntimeResult result in results ){
            OrderedList? list = GetOrderedListByType(listType);
            if (list == null) return;
            if (operation == "push"){
                stopWatch.Start();
                factory.PopulateList(list, result.InputSize);
                stopWatch.Stop();
                listNodeType = list.GetNodeType();
            }
            else if (operation == "pop"){
                if (list.Head == null){
                    factory.PopulateList(list, result.InputSize);
                }
                listNodeType = list.GetNodeType();
                stopWatch.Start();
                list.PopAll();
                stopWatch.Stop();
            }
            // We take times from Stopwatch and save them in the results
            result.Runtime = stopWatch.ElapsedMilliseconds;
        
        }
        System.Console.WriteLine("------------------------------");
        System.Console.WriteLine($"Testing {listType} {operation.ToUpper()} with nodes of type {listNodeType}");
        GetResultsSlope(results);
    }

    ///<summary>
    /// Calculates graph's slope between each 2 points
    ///</summary>
    public void GetResultsSlope(List<RuntimeResult> results){        
        double [] slopes = new double[results.Count-1];
        // Compare every two adjacent points of the graph data to calculate graph's slope
        for (int i = 0; i < results.Count-1; i++)
        {
            // m = (y2 - y1)/(x2 - x1)
            slopes[i] = Math.Round((double)(results[i+1].Runtime - results[i].Runtime) / (results[i+1].InputSize - results[i].InputSize), 2);
        }
        for (int i = 0; i < results.Count; i++)
        {
            System.Console.WriteLine($"Input size: {results[i].InputSize}, time: {results[i].Runtime}");
        }
        string inputSizes = results.Aggregate("", (i, j) =>  i.Length > 0 ? $"{i}, {j.InputSize.ToString()}" : j.InputSize.ToString());
        System.Console.WriteLine($"Input lists contain {inputSizes} items");
        System.Console.WriteLine($"The slopes are {string.Join(", ", slopes)}");
        if (slopes.Length > 1){
            // If the slope between each two points is different, the complefity of the function is not linear (not O(n))
            if (slopes[1] > slopes[0]){
                System.Console.WriteLine("The time complexity growth is not linear");
            }
            // If the slope between each two points is 0, the complexity of the function is O(1)
            else if (slopes[1] == slopes[0] && slopes[0] == 0){
                System.Console.WriteLine("The time complexity is O(1)");
            }
            // If the slope between each two points is a constant, the graph is linear and the complexity of the function is O(n)
            else if (slopes[1] == slopes[0]){
                System.Console.WriteLine("The time complexity growth is linear");
            }
        }
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
}

public class RuntimeResult{
    public int InputSize {get; set;}
    public long Runtime {get; set;} = 0;
}