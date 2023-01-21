namespace OrderedListNovidea;
/// <summary>
/// Class <Person> represents 
/// populates OrderedList with Person objects
/// </summary>
public class Person: IComparable{
    public string LastName {get; set;}
    public string FirstName {get; set;}
    public int YearOfBirth {get; set;}

    public Person(string lastName, string firstName, int year){
        LastName = lastName;
        FirstName = firstName;
        YearOfBirth = year;
    }

    /// <summary>
    /// Method <CompareTo>  allows comparing two Person objects based on YearOfBirth
    /// </summary>
    public int CompareTo(object p){
        if (p == null) return 0;
        Person anotherPerson = p as Person;
        if (anotherPerson == null || anotherPerson.YearOfBirth == 0) return 0;        
        return YearOfBirth - anotherPerson.YearOfBirth;
    }

    public override string ToString() => "Year of birth: " + YearOfBirth;
}