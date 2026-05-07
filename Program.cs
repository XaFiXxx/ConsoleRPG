using System.ComponentModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

class Character
{
    public string Nom { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int AttackPower { get; private set; }

    public Character(string nom, int health, int maxHealth, int attackPower)
    {
        Nom = nom;
        Health = health;
        MaxHealth = maxHealth;
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
        Health += (amountHeal);

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void StatsLvlUp()
    {
        MaxHealth += 50;
        AttackPower += 10;
    }
}

class Player : Character
{
    public int AmountHeal { get; private set; }
    public int HealQuantity { get; private set; }
    public int Xp { get; private set; }
    public int Level { get; private set; }
    public Player(string nom, int health, int maxHealth, int attackPower, int amountHeal, int healQuantity, int xp, int level)
        : base(nom, health, maxHealth, attackPower)
    {
        AmountHeal = amountHeal;
        HealQuantity = healQuantity;
        Xp = xp;
        Level = level;
    }

    public void UseHeal()
    {
        if (HealQuantity > 0)
        {
            Heal(AmountHeal);
            HealQuantity--;
        }
        else
        {
            Console.WriteLine("⚠️ Tu n'as plus de potions...!");
        }
    }

    public void AddXp()
    {
        Xp += 50;
        LevelUp();
    }

    public void LevelUp()
    {
        if (Xp >= 100)
        {
            Level++;
            Xp = 0;
            HealQuantity = 4;
            StatsLvlUp();
        }
    }
}

class Ennemy : Character
{
    public Ennemy(string nom, int health, int maxHealth, int attackPower)
        : base(nom, health, maxHealth, attackPower)
    {

    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Benjamin", 100, 100, 20, 20, 3, 0, 1);

        Console.WriteLine($"Bienvenue dans mon mini RPG {player.Nom}");

        while (!player.IsDead())
        {
            Ennemy zombie = new Ennemy("Zombie", 150, 150, 10);

            while (!zombie.IsDead() && !player.IsDead())
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
                        player.UseHeal();
                        Console.WriteLine($"{player.Nom} HP : {player.Health}");
                        Console.WriteLine($"Potions restantes : {player.HealQuantity}");
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
                player.AddXp();
                Console.WriteLine($"{player.Nom} gagne 50 XP !");
                Console.WriteLine($"Level : {player.Level}");
                Console.WriteLine($"XP total : {player.Xp}");
            }
        }
    }
}