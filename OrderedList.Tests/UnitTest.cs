using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
namespace OrderedListNovidea;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void QuickPopListInitialized()
    {
        QuickPopOrderedList quickPop = new QuickPopOrderedList();
        quickPop.Push(new Person("Jonson", "Tom", 2000));
        Assert.IsNotNull(quickPop.Head, "List initialization has failed");
    }

    public void QuickPopListIsOrdered()
    {
        Random random = new Random();
        QuickPopOrderedList quickPop = new QuickPopOrderedList();
        for (int i = 0; i < 10; i++)
        {
            quickPop.Push(new Person("Jonson", "Tom", random.Next(DateTime.Now.Year - 120, DateTime.Now.Year)));            
        }
        bool isOrdered = false;
        LinkedListNode pointer = quickPop.Head;
        while (pointer != null){
            if (pointer.Node.CompareTo(pointer.Next.Node) < 0){
                isOrdered = true;
                pointer = pointer.Next;
            }
            else{
                isOrdered = false;
                pointer = null;
            }
        }
        Assert.IsTrue(isOrdered, "Error creating QuickPopOrderedList: it is not ordered");
    }

    [TearDown]
    public void TestTearDown(){
        
    }
}