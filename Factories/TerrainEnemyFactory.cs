namespace WitcherTextRpg.Factories;

using WitcherTextRpg.Characters;
using WitcherTextRpg.World;

public sealed class TerrainEnemyFactory : IEnemyFactory
{
    private readonly Random _random = new();

    public Enemy CreateEnemy(Terrain terrain, int playerLevel)
    {
        var level = Math.Max(terrain.RequiredLevel, playerLevel + _random.Next(0, 2));

        return terrain.Type switch
        {
            TerrainType.Forest => _random.Next(2) == 0
                ? new Monster("Wilk", level)
                : new Warrior("Bandyta", level),
            TerrainType.Swamp => new Monster("Utopiec", level + 1),
            TerrainType.Cave => _random.Next(4) == 0
                ? new BossEnemy("Wampir", level + 2)
                : new Monster("Ghoul", level + 1),
            TerrainType.Village => new Warrior("Najemnik", level),
            _ => new Monster("Potwór", level)
        };
    }
}
