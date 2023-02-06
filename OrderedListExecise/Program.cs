
namespace OrderedListNovidea;
class Program{
    static void Main(string [] args){
        Console.WriteLine("Ordered List Exercise");

        /* SortingTest sortingTest = new SortingTest(10);
        sortingTest.TestLists(); */
        
        BigOTest bigOTest = new BigOTest();
        bigOTest.TestLists();

        /*MultiThreadingTest multiThreadingTest = new MultiThreadingTest(new SortingTest(7), 20);
        multiThreadingTest.TestLists(); */
     }
}