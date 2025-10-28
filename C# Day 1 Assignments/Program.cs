// See https://aka.ms/new-console-template for more information

using C__Day_1_Assignments;

PlayingWithConsoleApp a = new PlayingWithConsoleApp();
//a.Con();

UnderstandingTypes u = new UnderstandingTypes();
//u.TypeValuesAndSize();
//u.CenturyConverter(1);

//int b = 2147483647;
//b++;
//Console.WriteLine(b);

LoopsAndOperators l = new LoopsAndOperators();
//l.FizzBuzz();
//l.Counting();

int[] array = new int[] {2,1, 1, 2, 3, 3, 2, 2, 2, 1};
PracticeArrays p = new PracticeArrays();
//p.CopyArray(array);
//p.ListManager();
/*int[] arr = p.FindPrimesInRange(10, 50);
Console.WriteLine("Prime numbers between 10 and 50:");
foreach (int num in arr) {
    Console.Write(num + " ");
}*/

/*int [] output = p.AddRotatingArray(array, 2);
for(int i = 0; i < array.Length; i++) {
    Console.Write(output[i] + " ");
}*/

/*int [] output = p.LongestSequenceOfEqualElements(array);
for(int i = 0; i < output.Length; i++) {
    Console.Write(output[i] + " ");
}*/

//p.MostFrequentNumber(array);

PracticeStrings ps = new PracticeStrings();
//ps.ReverseStringUsingCharArray("Ryan");
//ps.ReverseStringUsingForLoop("Ryan");
//string output = ps.ReverseSentence("C# is not C++, and PHP is not Delphi!");
//Console.WriteLine(output);
//ps.FindPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
ps.ParseUrl("https://www.apple.com/iphone");


