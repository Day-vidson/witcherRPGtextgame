namespace WitcherTextRpg.World;

public sealed class WorldMap
{
    private readonly List<Terrain> _terrains = new()
    {
        new Terrain(TerrainType.Forest, 1, 1),
        new Terrain(TerrainType.Village, 1, 1),
        new Terrain(TerrainType.Swamp, 2, 2),
        new Terrain(TerrainType.Cave, 3, 3)
    };

    public IReadOnlyList<Terrain> Terrains => _terrains;
    public List<Terrain> GetAvailableTerrains(int level) => _terrains.Where(t => t.RequiredLevel <= level).ToList();
    public void UnlockTerrain(int level) { /* Terrains are unlocked by level, so no extra state is needed. */ }
}
