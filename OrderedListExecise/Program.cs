
namespace OrderedListNovidea;
class Program{
    static void Main(string [] args){
        Console.WriteLine("Ordered List Exercise");

        SortingTest sortingTest = new SortingTest();
        sortingTest.TestLists();

        BigOTest test = new BigOTest();
        test.TestLists();
    }
}