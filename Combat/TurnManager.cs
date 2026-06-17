namespace WitcherTextRpg.Combat;

using WitcherTextRpg.Characters;

public sealed class TurnManager
{
    private readonly Queue<Character> _turns = new();

    public void Initialize(Player player, Enemy enemy)
    {
        _turns.Clear();

        if (player.Stats.Speed >= enemy.Stats.Speed)
        {
            _turns.Enqueue(player);
            _turns.Enqueue(enemy);
        }
        else
        {
            _turns.Enqueue(enemy);
            _turns.Enqueue(player);
        }
    }

    public Character NextTurn()
    {
        var character = _turns.Dequeue();
        _turns.Enqueue(character);
        return character;
    }

    public bool CanAct(Character character) => character.IsAlive();
}
