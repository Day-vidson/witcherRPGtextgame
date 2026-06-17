namespace WitcherTextRpg.Events;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Services;
using WitcherTextRpg.UI;

public sealed class QuestEvent : IExplorationEvent
{
    private readonly Quest _quest;
    private readonly IGameUI _ui;

    public QuestEvent(Quest quest, IGameUI ui)
    {
        _quest = quest;
        _ui = ui;
    }

    public void Trigger(Player player)
    {
        _ui.ShowMessage($"Znaleziono zadanie: {_quest.Title}");
        _quest.Complete(player);
        _ui.ShowMessage("Zadanie ukończone. Otrzymano nagrodę.");
    }
}
