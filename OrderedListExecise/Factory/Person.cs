namespace OrderedListNovidea;
public class Person: IComparable{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int YearOfBirth {get; set;}

    public Person(string ln, string fn, int year){
        LastName = ln;
        FirstName = fn;
        YearOfBirth = year;
    }

    public int CompareTo(object p){
        if (p == null) return 0;
        Person anotherPerson = p as Person;
        if (anotherPerson == null || anotherPerson.YearOfBirth == 0) return 0;        
        return YearOfBirth - anotherPerson.YearOfBirth;
    }

    public override string ToString(){
       return "Year of birth: " + YearOfBirth;
    }
}