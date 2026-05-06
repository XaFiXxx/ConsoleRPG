using System.ComponentModel;
using System.Dynamic;

class Character
{
    public string Nom { get; private set; }
    public int Health { get; private set; }
    public int AttackPower { get; private set; }

    public Character(string nom, int health, int attackPower)
    {
        Nom = nom;
        Health = health;
        AttackPower = attackPower;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public void Attack(Character target)
    {
        target.TakeDamage(AttackPower);
    }
}

class Player : Character
{
    public Player(string nom, int health, int attackPower)
        : base(nom, health, attackPower)
    {

    }
}

class Ennemy : Character
{

    public Ennemy(string nom, int health, int attackPower)
        : base(nom, health, attackPower)
    {

    }
}

class Program
{

    static void Main()
    {
        Player player = new Player("Benjamin", 100, 20);
        Ennemy zombie = new Ennemy("Zombie", 50, 10);

        player.Attack(zombie);

        Console.WriteLine(zombie.Health);
    }
}