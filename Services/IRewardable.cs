namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;

public interface IRewardable
{
    void GiveReward(Player player);
}
