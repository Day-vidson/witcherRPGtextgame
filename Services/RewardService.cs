namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;

public sealed class RewardService
{
    public void Grant(IRewardable rewardable, Player player)
    {
        rewardable.GiveReward(player);
    }
}
