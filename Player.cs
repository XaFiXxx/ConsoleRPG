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