namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;

public sealed class Quest : IRewardable
{
    public string Title { get; }
    public int RequiredLevel { get; }
    public bool IsCompleted { get; private set; }
    public int ExperienceReward { get; }
    public int GoldReward { get; }

    public Quest(string title, int requiredLevel, int experienceReward, int goldReward)
    {
        Title = title;
        RequiredLevel = requiredLevel;
        ExperienceReward = experienceReward;
        GoldReward = goldReward;
    }

    public void Complete(Player player)
    {
        if (IsCompleted || player.Level < RequiredLevel) return;

        IsCompleted = true;
        GiveReward(player);
    }

    public void GiveReward(Player player)
    {
        player.GainExperience(ExperienceReward);
        player.AddGold(GoldReward);
    }
}
