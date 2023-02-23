using System.Collections.ObjectModel;
using System.Collections.Specialized;

var people3 = new ObservableCollection<Person> { new Person("Tom"), new Person("Bob"), new Person("Sam") };

people3.CollectionChanged+= People_CollectionChanged;
                                               // Output
people3.Add(new Person("Mike"));                //Object Mike added.
people3.Insert(1, new Person("Alice"));         //Object Alice added.
people3.RemoveAt(4);                            //Object Mike removed.
people3[0] = new Person("Eugene");              //Object Tom was replaced by Eugene

Console.WriteLine("-----------------------");
                                                // Output
Console.WriteLine("List of users: ");           //List of users:
foreach (var person in people3)                 //Eugene
{                                               //Alice
    Console.WriteLine(person.Name);             //Bob
}                                               //Sam
void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
{
switch (e.Action)
{
case NotifyCollectionChangedAction.Add:
if (e.NewItems?[0] is Person newPerson)
Console.WriteLine($"Object {newPerson.Name} added.");
break;
case NotifyCollectionChangedAction.Remove:
if (e.OldItems?[0] is Person oldPerson)
Console.WriteLine($"Object {oldPerson.Name} removed.");
break;
case NotifyCollectionChangedAction.Replace:
if ((e.NewItems?[0] is Person replacingPerson)  &&
    (e.OldItems?[0] is Person replacedPerson))
Console.WriteLine($"Object {replacedPerson.Name} was replaced by {replacingPerson.Name}");
break;
}}

Console.ReadKey();
class Person {
    public string Name { get; set; }
    public Person(string name) => Name = name;
}





