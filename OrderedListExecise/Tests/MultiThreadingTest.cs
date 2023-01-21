using System.Diagnostics;

namespace OrderedListNovidea;

/// <summary>
/// Class MultiThreadingTest runs a supplied test that supports IRunLIstTest interface
/// in a supplied number of Threads
/// </summary>
public class MultiThreadingTest: IRunListTest{

    public IRunListTest TestToRun;
    public int ThreadsCount;
    public MultiThreadingTest(IRunListTest test, int threads = 100){
        TestToRun = test;
        ThreadsCount = threads;
    }

    public void TestLists(){
        System.Console.WriteLine("*** Multithreading Tests ***");
        
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < ThreadsCount; i++)
        {
            Thread thread = new Thread(TestToRun.TestLists);
            thread.Start();
        }
        stopWatch.Stop();
        System.Console.WriteLine($"{TestToRun} have run for {stopWatch.ElapsedMilliseconds}");
    }
}

