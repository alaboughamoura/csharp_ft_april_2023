public class Medic : Soldier
{
    // Attributes
    public double Healing {get;set;}

    // Constructors
    public Medic (string name, int age, double heal) : base( name,  age)
    {
        Healing = heal;
    }
    // Methods
    public void Cure(Soldier patient)
    {
        patient.Health+= Healing/2;
        Console.WriteLine($"[Heal] The Medic {Name} Cured the Soldier {patient.Name} and he has {patient.Health} HP .");
    }
}