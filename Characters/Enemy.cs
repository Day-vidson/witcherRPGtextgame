namespace WitcherTextRpg.Characters;

using WitcherTextRpg.Combat;
using WitcherTextRpg.Items;
using WitcherTextRpg.Services;

public abstract class Enemy : Character, IRewardable
{
    protected readonly List<Item> LootTable = new();
    public int Level { get; }
    public int ExperienceReward { get; }
    public int GoldReward { get; }

    protected Enemy(string name, int level, int maxHealth, int stamina, Stats stats, int experienceReward, int goldReward)
        : base(name, maxHealth, stamina, stats)
    {
        Level = level;
        ExperienceReward = experienceReward;
        GoldReward = goldReward;
    }

    public abstract ICombatAction ChooseAction();

    public virtual void GiveReward(Player player)
    {
        player.GainExperience(ExperienceReward);
        player.AddGold(GoldReward);
    }
}
