public class Sniper : Soldier, IHaveWeapon // Inheritance 
{
    // Specific Attributes for the Child class
    public bool EagleEye;
    public double HeadShot;
    public double Hidden;
    public string Weapon {get;set;}
    public int NumberOfBullets {get;set;}

    public Sniper(string name , int age):base(name, age) // calling one of the constructors of the parent Class (Soldier)
    {
        EagleEye = true;
        HeadShot = 0.8;
        Hidden = 0.75;
        Weapon = "Sniper";
        NumberOfBullets = 20;
    }
    // Polymorphism :  Overriding the parent method 
    // Override Method  :  Change the parent class method 
    public override double Train(double amount)
    {
       Power+=amount*2;
       return Power;
    }
    public void Shoot()
    {
        System.Console.WriteLine("Pow ");
    }
}