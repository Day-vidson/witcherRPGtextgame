namespace WitcherTextRpg.Factories;

using WitcherTextRpg.Characters;
using WitcherTextRpg.World;

public interface IEnemyFactory
{
    Enemy CreateEnemy(Terrain terrain, int playerLevel);
}
