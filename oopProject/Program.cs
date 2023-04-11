Soldier alex = new Soldier("Alex",32);

// Console.WriteLine($"Name : {alex.Name}\nAge:{alex.Age}");

Soldier bob  = new Soldier("Bob", 35,1.2,2.5);
// alex.ShowInfo();
// bob.ShowInfo();
alex.Age+=1;
// alex.ShowInfo();
// alex.Attack(bob,2);:
// bob.ShowInfo();

Sniper sam = new Sniper("Sam", 45);
sam.ShowInfo();
System.Console.WriteLine(sam.EagleEye);