
//* Data Types
// JavaScript  let name = "Alex"
// Python name  = "Alex"
// !Naming Convention PascalCase : every first letter of every word UpperCase
// String :  multiple Characters
string UserName = "Alex";
// Console.WriteLine(UserName);
// Char : one single character
// name = 7;

// - Numbers 

// Integer
int AlexAge  = 25;
// Console.WriteLine(value:AlexAge);
// Float = 32bits
float Rate = 1.20f;

// Decimal = 64bits
decimal tax = 1.0515M;

// Boolean
bool IsValid = true;
bool IsAdmin = false;

// * Data Structure

// Array 
int[] FirstArray = new int[5]{1,2,3,4,5};
// Console.WriteLine(FirstArray);
float[] SecondArray = {1.25f,0.89f,5.75f};

// List
// new Object or new instance of the class
List<string> names = new List<string>();
names.Add(UserName);
names.Add("15");
names.Add("Sarah");
// names.Remove("15");
// names.RemoveAt(1);
// names.RemoveAll();
// Console.WriteLine(names[1]);

// Dictionary
//- Specify the type|| variable name||Initializing a new instance of the class Dictionary
Dictionary<int,string> FirstDict = new Dictionary<int, string>() {
    {1,"Alex"},{2,"Sarah"}
};

// Conditionals 

// if(AlexAge >= 30)
// {
//     Console.WriteLine("Hello Alex");
// }
// else if (AlexAge == 25)
// {
//     Console.WriteLine("Here you are");
// }
// else 
// {
//     Console.WriteLine("Please Go Home");
// }

// Loops 

// for (int i  = 0 ;i<6;i++)
// {
//     Console.WriteLine(i);
// }

// for (int i = 0; i< FirstArray.Count(); i++)
// {
//     Console.WriteLine(FirstArray[i]);
// }
// for (int i = 0; i< names.Count(); i++)
// {
//     Console.WriteLine(names[i]);
// }

// foreach(int element in FirstArray) 
// {
//     Console.WriteLine(element);
// }
// foreach(string name in names) 
// {
//     Console.WriteLine(name);
// }
// int score = 0;

// while(score < 5)
// {
//     Console.WriteLine("Still Not yet");
//     score ++;
// }
// ! Implicit Casting 
// int IntegerValue = 65;
// double DoubleValue = IntegerValue;
// Console.WriteLine($"The Integer Value  = {IntegerValue} and \n the Double is  = {DoubleValue}");
// !Explicit Casting
double DoubleValue = 3.999999999999999999;
int IntegerValue = (int)DoubleValue;
// IntegerValue == 3

// Console.WriteLine($"The Integer Value  = {IntegerValue} and \n the Double is  = {DoubleValue}");

// * Functions
static int SayHello ()
{
    Console.WriteLine("Hello");
    return  3;
}
SayHello();

static int add (int a, int b, int sum  = 0)
{
    // Console.WriteLine("Hello");
    sum  = sum +a+b;
    Console.WriteLine($"The Sum of {a} and {b} is equal to : {sum}");
    return  sum;
}
int result = add(5,4);