public class Commando : Soldier
{
    // Specific Attributes of the Commando Class
    public string Weapon = "Machine Gun";
    public double Strength {get;set;}
    public double Durability {get;set;}

    // Constructors
    public Commando(string name , int age, double strg) : base(name,age)
    {
        Strength = strg;
        Durability = 0.65;
    }
}