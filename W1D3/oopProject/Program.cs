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
Medic taylor = new Medic("Taylor", 50,0.8);
sam.ShowInfo();
System.Console.WriteLine(sam.EagleEye);

//  Army 
List<Soldier> Army = new List<Soldier>();
Army.Add(alex);
Army.Add(bob);
Army.Add(sam);
Army.Add(taylor);
List<Sniper> snipers = new List<Sniper>();
snipers.Add(sam);
// snipers.Add(alex);

// Gang
List<Gangsta> pirrow = new List<Gangsta>();
Gangsta t_12  = new Gangsta("T-12", 24);
pirrow.Add(t_12);