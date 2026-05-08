using System.Xml.Linq;

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
        Health = MaxHealth;
    }
}