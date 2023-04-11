/*
class Soldier {
    constructor{
        Attributes
    }
}
class Soldier : 
    def __init__():
        Attributes
*/

public class Soldier 
{
    // Attributes
    // - Access Modifier -- Data Type --- Attribute
    public string Name {get;set;}
    public int Age {get;set;}
    public double Health {get;set;}
    public double Power {get;set;}

    // Constructors * (Multiple Constructors) 
    public Soldier (string name, int age)
    {
        Name = name;
        Age = age;
        Power = 0.5;
        Health = 1;
    }

    public Soldier (string n, int a, double power, double health)
    {
        Name = n;
        Age = a;
        Power = power;
        Health  = health;
    }
    // Methods
    public void ShowInfo()
    {
        Console.WriteLine($"Name : {Name}\nAge : {Age}\n Power : {Power}\nHealth : {Health}");
    }
    public int IncreaseAge() 
    {
        Age+=1;
        return Age;
    }
    public virtual double Train (double amount)
    {
        Power+=amount;
        return Power;
    }
    public void Attack (Soldier target,double rate)
    {
        target.Health -= Power/rate;
        Console.WriteLine($"[ATTACK] Soldier {Name} attacked Solider {target.Name}\n by rate equals to {rate} and cause damage  equal to {Power/rate}");
    }
}

