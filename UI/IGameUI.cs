namespace WitcherTextRpg.UI;

using WitcherTextRpg.Characters;

public interface IGameUI
{
    void ShowMessage(string text);
    int ReadChoice();
    void ShowCharacter(Character character);
}
