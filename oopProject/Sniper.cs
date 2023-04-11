public class Sniper : Soldier
{
    public bool EagleEye;
    public double HeadShot;
    public double Hidden;
    public string Weapon = "Sniper";

    public Sniper(string name , int age):base(name, age)
    {
        EagleEye = true;
        HeadShot = 0.8;
        Hidden = 0.75;
    }
    public override double Train(double amount)
    {
       Power+=amount*2;
       return Power;
    }
}