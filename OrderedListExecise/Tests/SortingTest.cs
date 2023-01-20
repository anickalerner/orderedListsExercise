namespace OrderedListNovidea;

public class SortingTest{

    public SortingTest(){
        
        DateListFactory dateFactory = new DateListFactory();
        
        QuickPushOrderedList datePushList = new QuickPushOrderedList();
        dateFactory.PopulateList(datePushList, 10);        
        RunListTest(datePushList);
        
        QuickPopOrderedList datePopList = new QuickPopOrderedList();
        dateFactory.PopulateList(datePopList, 10);        
        RunListTest(datePopList);

        PersonListFactory personFactory = new PersonListFactory();

        QuickPushOrderedList personPushList = new QuickPushOrderedList();
        personFactory.PopulateList(personPushList, 10);        
        RunListTest(personPushList);
        
        QuickPopOrderedList personPopList = new QuickPopOrderedList();
        personFactory.PopulateList(personPopList, 10);        
        RunListTest(personPopList);
        
    }

        public void RunListTest(OrderedList? list){
        System.Console.WriteLine("******************************");
        System.Console.WriteLine("{0} list run with {1}", list?.Name, list?.Head?.Node.GetType().ToString());
        System.Console.WriteLine("");
        System.Console.WriteLine("Newly populated {0}:", list?.Name);
        System.Console.WriteLine("-----------------------");        
        list?.Print();
        
        System.Console.WriteLine("");
        System.Console.WriteLine("Pop from {0} list", list?.Name);
        System.Console.WriteLine("-----------------------");
        list?.PopAllAndPrint();
    }

}