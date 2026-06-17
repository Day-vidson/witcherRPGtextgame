namespace WitcherTextRpg.Characters;

public abstract class Character
{
    public string Name { get; }
    public int MaxHealth { get; protected set; }
    public int Health { get; protected set; }
    public int Stamina { get; protected set; }
    public Stats Stats { get; }

    protected Character(string name, int maxHealth, int stamina, Stats stats)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Stamina = stamina;
        Stats = stats;
    }

    public virtual void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - Math.Max(0, damage));
    }

    public void Heal(int value)
    {
        Health = Math.Min(MaxHealth, Health + Math.Max(0, value));
    }

    public void RestoreStamina() => Stamina += 10;

    public bool SpendStamina(int amount)
    {
        if (Stamina < amount) return false;
        Stamina -= amount;
        return true;
    }

    public bool IsAlive() => Health > 0;
}
