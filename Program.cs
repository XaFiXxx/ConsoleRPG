using System.ComponentModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Player player = new Player("Benjamin", 100, 100, 20, 20, 3, 0, 1);

        Console.WriteLine($"Bienvenue dans mon mini RPG {player.Nom}");
        Console.WriteLine($"Vous commencez la partie avec {player.Health} PV et {player.AttackPower} points de dégats.");
        Console.WriteLine($"Vous possédez aussi {player.HealQuantity} potions.");
        Console.WriteLine($"----------------------------------");

        while (!player.IsDead())
        {
            Ennemy ennemy = new Ennemy("Zombie", 150, 150, 10);
            Console.WriteLine($"OHHHHHH!!! Un {ennemy.Nom} apparait.");

            while (!ennemy.IsDead() && !player.IsDead())
            {
                Console.WriteLine($"1. Attaquer le {ennemy.Nom}");
                Console.WriteLine("2. Prendre une potion");
                Console.WriteLine("4. Arreté de jouer");

                string input = Console.ReadLine() ?? "";


                switch (input)
                {
                    case "1":
                        player.Attack(ennemy);
                        Console.WriteLine($"{ennemy.Nom} HP : {ennemy.Health}");

                        if (ennemy.IsDead())
                            break;

                        ennemy.Attack(player);
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
                Console.WriteLine($"{ennemy.Nom} est mort ! ☠️");
                player.AddXp();
                Console.WriteLine($"{player.Nom} gagne 50 XP !");
                Console.WriteLine($"Level : {player.Level}");
                Console.WriteLine($"XP total : {player.Xp}");
            }
        }
    }
}