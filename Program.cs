using System.ComponentModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

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

        if (Health <= 0)
        {
            Health = 0;
        }
    }

    public void Attack(Character target)
    {
        target.TakeDamage(AttackPower);
        Console.WriteLine($"{Nom} attaque {target.Nom}");
    }

    public void Heal(int amountHeal)
    {
        Health += amountHeal;
    }

    public bool IsDead()
    {
        return Health <= 0;
    }
}

class Player : Character
{
    public int AmountHeal { get; private set; }
    public Player(string nom, int health, int attackPower, int amountHeal)
        : base(nom, health, attackPower)
    {
        AmountHeal = amountHeal;
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
        Player player = new Player("Benjamin", 100, 20, 20);
        Ennemy zombie = new Ennemy("Zombie", 150, 10);

        Console.WriteLine($"Bienvenue dans mon mini RPG {player.Nom}");


        while (!player.IsDead() && !zombie.IsDead())
        {
            Console.WriteLine("1. Attaquer l'ennemi");
            Console.WriteLine("2. Prendre une potion");
            Console.WriteLine("4. FUIR...!");

            string input = Console.ReadLine() ?? "";


            switch (input)
            {
                case "1":
                    player.Attack(zombie);
                    Console.WriteLine($"{zombie.Nom} HP : {zombie.Health}");

                    if (zombie.IsDead())
                        break;

                    zombie.Attack(player);
                    Console.WriteLine($"{player.Nom} HP : {player.Health}");
                    break;

                case "2":
                    player.Heal(player.AmountHeal);
                    Console.WriteLine($"{player.Nom} HP : {player.Health}");
                    break;

                case "4":
                    Console.WriteLine("Tu as quitté le combat..!");
                    return;

                default:
                    Console.WriteLine("❌ Choix invalide..!");
                    break;
            }


        }

        if (player.IsDead())
        {
            Console.WriteLine($"{player.Nom} est mort !");
        }
        else
        {
            Console.WriteLine($"{zombie.Nom} est mort ! ☠️");
        }
    }
}