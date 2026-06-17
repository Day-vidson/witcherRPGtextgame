namespace WitcherTextRpg.World;

using WitcherTextRpg.Characters;

public sealed class Terrain
{
    public TerrainType Type { get; }
    public int RequiredLevel { get; }
    public int Difficulty { get; }

    public Terrain(TerrainType type, int requiredLevel, int difficulty)
    {
        Type = type;
        RequiredLevel = requiredLevel;
        Difficulty = difficulty;
    }

    public bool CanEnter(Player player) => player.Level >= RequiredLevel;

    public override string ToString() => $"{Type} (level {RequiredLevel}+, difficulty {Difficulty})";
}
