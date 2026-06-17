namespace WitcherTextRpg.Services;

using WitcherTextRpg.Characters;

public sealed class ScoreBoard
{
    private readonly List<ScoreEntry> _entries = new();
    public IReadOnlyList<ScoreEntry> Entries => _entries;

    public void AddResult(Player player)
    {
        _entries.Add(new ScoreEntry(player.Name, player.Level));
    }

    public List<ScoreEntry> GetTopWitchers()
    {
        return _entries
            .OrderByDescending(entry => entry.MaxLevel)
            .Take(10)
            .ToList();
    }
}
