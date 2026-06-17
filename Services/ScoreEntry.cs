namespace WitcherTextRpg.Services;

public sealed class ScoreEntry
{
    public string WitcherName { get; }
    public int MaxLevel { get; }

    public ScoreEntry(string witcherName, int maxLevel)
    {
        WitcherName = witcherName;
        MaxLevel = maxLevel;
    }
}
