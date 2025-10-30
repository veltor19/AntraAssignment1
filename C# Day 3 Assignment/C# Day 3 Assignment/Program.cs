// See https://aka.ms/new-console-template for more information

using C__Day_3_Assignment;

/*
Stack<int> numbers = new Stack<int>();
numbers.Push(10);
numbers.Push(20);
Console.WriteLine($"Count: {numbers.Count()}");
Console.WriteLine($"Popped: {numbers.Pop()}");

MyList<string> myList = new MyList<string>(2);
myList.Add("first");
myList.Add("second");
myList.Add("third");
var a = myList.Remove(1);
Console.WriteLine(myList.Contains("second")); // False

*/

Repository<Entity> repository = new Repository<Entity>();
repository.Add(new Entity { Id = 1});
repository.Add(new Entity { Id = 2});
repository.Save();
repository.GetAll().ToList().ForEach(e => Console.WriteLine($"Entity Id: {e.Id}"));
