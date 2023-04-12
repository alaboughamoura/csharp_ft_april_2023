public class Gangsta : IHaveWeapon
{
    // Attributes
    public string Nickname {get;set;}
    public int Age { get; set; }
    public double Health { get; set; }
    public double Power { get; set; }
    public string Weapon {get;set;}
    public int NumberOfBullets {get;set;}

    // Constructors
    public Gangsta (string nickname, int age)
    {
        Nickname = nickname;
        Age = age;
        Health  = 1;
        Power = 0.75;
        Weapon = "AKA 47";
        NumberOfBullets = 100;
    }
    public void Shoot()
    {
        NumberOfBullets -=2;
    }
}