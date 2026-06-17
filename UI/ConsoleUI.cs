namespace WitcherTextRpg.UI;

using WitcherTextRpg.Characters;

public sealed class ConsoleUI : IGameUI
{
    public void ShowMessage(string text) => Console.WriteLine(text);

    public int ReadChoice()
    {
        Console.Write("> ");
        var input = Console.ReadLine();
        return int.TryParse(input, out var choice) ? choice : -1;
    }

    public void ShowCharacter(Character character)
    {
        Console.WriteLine($"{character.Name} | HP: {character.Health}/{character.MaxHealth} | Stamina: {character.Stamina} | STR: {character.Stats.Strength} | DEX: {character.Stats.Dexterity} | INT: {character.Stats.Intelligence}");
    }
}
