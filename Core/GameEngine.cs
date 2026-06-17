namespace WitcherTextRpg.Core;

using WitcherTextRpg.Characters;
using WitcherTextRpg.Factories;
using WitcherTextRpg.Items;
using WitcherTextRpg.Services;
using WitcherTextRpg.UI;
using WitcherTextRpg.World;

public sealed class GameEngine
{
    private readonly IGameUI _ui;
    private readonly CombatService _combat;
    private readonly IEnemyFactory _enemyFactory;
    private readonly IExplorationEventFactory _eventFactory;
    private readonly WorldMap _map = new();
    private readonly Shop _shop = new();
    private readonly ScoreBoard _scoreBoard = new();
    private Player _player = new("Geralt");
    private bool _isRunning;

    public GameEngine(
        IGameUI ui,
        CombatService combat,
        IEnemyFactory enemyFactory,
        IExplorationEventFactory eventFactory)
    {
        _ui = ui;
        _combat = combat;
        _enemyFactory = enemyFactory;
        _eventFactory = eventFactory;
    }

    public void Start()
    {
        _ui.ShowMessage("=== Wiedźmiński tekstowy RPG ===");
        _ui.ShowMessage("Podaj imię wiedźmina:");
        var name = Console.ReadLine();
        _player = new Player(string.IsNullOrWhiteSpace(name) ? "Geralt" : name.Trim());

        GiveStartingItems();
        _isRunning = true;

        while (_isRunning && _player.IsAlive())
        {
            ShowMainMenu();
            HandleMainChoice(_ui.ReadChoice());
        }

        _scoreBoard.AddResult(_player);
        _ui.ShowMessage("Koniec gry.");
        ShowScore();
    }

    public void Explore()
    {
        var availableTerrains = _map.GetAvailableTerrains(_player.Level);
        _ui.ShowMessage("Wybierz teren do eksploracji:");

        for (var i = 0; i < availableTerrains.Count; i++)
            _ui.ShowMessage($"{i + 1}. {availableTerrains[i]}");

        var choice = _ui.ReadChoice() - 1;
        if (choice < 0 || choice >= availableTerrains.Count)
        {
            _ui.ShowMessage("Niepoprawny wybór.");
            return;
        }

        var terrain = availableTerrains[choice];
        _player.CurrentTerrain = terrain;

        var explorationEvent = _eventFactory.CreateEvent(terrain, _player.Level);
        explorationEvent.Trigger(_player);
    }

    public void OpenShop()
    {
        _ui.ShowMessage($"Złoto: {_player.Gold}");
        _ui.ShowMessage("Oferta sklepu:");

        foreach (var item in _shop.Offer)
            _ui.ShowMessage($"{item.Id}. {item.Name} | cena: {item.Price} | wymagany poziom: {item.RequiredLevel}");

        _ui.ShowMessage("Wpisz id przedmiotu do kupienia albo 0, aby wrócić.");
        var id = _ui.ReadChoice();
        if (id == 0) return;

        var success = _shop.Buy(id, _player);
        _ui.ShowMessage(success ? "Kupiono przedmiot." : "Nie udało się kupić przedmiotu.");
    }

    public void ShowScore()
    {
        _ui.ShowMessage("=== Ranking wiedźminów ===");
        foreach (var entry in _scoreBoard.GetTopWitchers())
            _ui.ShowMessage($"{entry.WitcherName} - poziom {entry.MaxLevel}");
    }

    private void ShowMainMenu()
    {
        _ui.ShowMessage("");
        _ui.ShowCharacter(_player);
        _ui.ShowMessage($"Złoto: {_player.Gold} | XP: {_player.Experience} | Poziom: {_player.Level}");
        _ui.ShowMessage("1 - Eksploruj");
        _ui.ShowMessage("2 - Sklep");
        _ui.ShowMessage("3 - Ekwipunek");
        _ui.ShowMessage("4 - Ranking");
        _ui.ShowMessage("0 - Wyjście");
    }

    private void HandleMainChoice(int choice)
    {
        switch (choice)
        {
            case 1: Explore(); break;
            case 2: OpenShop(); break;
            case 3: ShowInventory(); break;
            case 4: ShowScore(); break;
            case 0: _isRunning = false; break;
            default: _ui.ShowMessage("Niepoprawny wybór."); break;
        }
    }

    private void ShowInventory()
    {
        if (!_player.Inventory.Items.Any())
        {
            _ui.ShowMessage("Ekwipunek jest pusty.");
            return;
        }

        _ui.ShowMessage("Ekwipunek:");
        foreach (var item in _player.Inventory.Items)
            _ui.ShowMessage($"{item.Id}. {item.Name}");

        _ui.ShowMessage("Wpisz id przedmiotu do użycia/założenia albo 0, aby wrócić.");
        var id = _ui.ReadChoice();
        if (id == 0) return;

        var selectedItem = _player.Inventory.FindById(id);
        if (selectedItem is null)
        {
            _ui.ShowMessage("Nie znaleziono przedmiotu.");
            return;
        }

        selectedItem.Use(_player);
        if (selectedItem is Potion)
            _player.Inventory.Remove(selectedItem);

        _ui.ShowMessage($"Użyto przedmiotu: {selectedItem.Name}");
    }

    private void GiveStartingItems()
    {
        var sword = new Weapon(10, "Początkowy miecz", 0, 1, 5);
        var armor = new Armor(11, "Początkowa zbroja", 0, 1, 2);
        var potion = new Potion(12, "Mała Jaskółka", 0, 1, "Heal");

        _player.Inventory.Add(sword);
        _player.Inventory.Add(armor);
        _player.Inventory.Add(potion);
        sword.Use(_player);
        armor.Use(_player);
    }
}
