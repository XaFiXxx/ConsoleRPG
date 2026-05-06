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

    public Ennemy(string nom, int health, int attackPower, int damage)
        : base(nom, health, attackPower)
    {

    }
}