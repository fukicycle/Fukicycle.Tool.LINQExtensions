# Fukicycle.Tool.LINQExtensions

## Sample code
```cs
using Fukicycle.Tool.LINQExtensions;
Item[] items = [
    new(1, "Name1"), new(2, "Name2"), new(3, "Name3"),
    new (4,"Name4"),new (5,"Name5"),new (6,"Name6"),
    new(7, "Name7"), new(8, "Name8"), new(9, "Name9")];

//String join
Console.WriteLine("String join 1.");
string oneLine = items.JoinToString(" # ");
Console.WriteLine(oneLine);

//Specified display text.
Console.WriteLine("String join 2.");
string oneLine2 = items.JoinToString(a => a.Name);
Console.WriteLine(oneLine2);

//Get random value.
//Single item
Item singleItem = items.TakeRandomValue();
Console.WriteLine("Random single item.");
Console.WriteLine(singleItem.Name);

//Multiple items
IEnumerable<Item> randomItems = items.TakeRandomValues(3);
Console.WriteLine("Random three items.");
Console.WriteLine(randomItems.JoinToString(a => a.Name));

//Grouping by specified count.
Console.WriteLine("A specified number of groupings.");
var groupingItem = items.GroupByCount(3);
foreach (var item in groupingItem)
{
    Console.Write("Key (index):");
    Console.WriteLine(item.Key);
    Console.WriteLine(item.JoinToString(a => a.Name));
}

//Shuffle
Console.WriteLine("Original");
Console.WriteLine(items.JoinToString(a => a.Name));
Console.WriteLine("Shuffle 1");
Console.WriteLine(items.Shuffle().JoinToString(a => a.Name));
Console.WriteLine("Shuffle 2");
Console.WriteLine(items.Shuffle().JoinToString(a => a.Name));

class Item
{
    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
```

## Results
```shell
who@someoneMacBook-Pro tmp % dotnet run
String join 1.
Item # Item # Item # Item # Item # Item # Item # Item # Item
String join 2.
Name1,Name2,Name3,Name4,Name5,Name6,Name7,Name8,Name9
Random single item.
Name3
Random three items.
Name2,Name7,Name9
A specified number of groupings.
Key (index):0
Name1,Name2,Name3
Key (index):1
Name4,Name5,Name6
Key (index):2
Name7,Name8,Name9
Original
Name1,Name2,Name3,Name4,Name5,Name6,Name7,Name8,Name9
Shuffle 1
Name2,Name8,Name4,Name6,Name3,Name7,Name5,Name9,Name1
Shuffle 2
Name6,Name4,Name8,Name2,Name1,Name7,Name3,Name5,Name9
who@someoneMacBook-Pro tmp %
```
