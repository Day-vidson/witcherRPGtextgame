using WitcherTextRpg.Core;
using WitcherTextRpg.Factories;
using WitcherTextRpg.Services;
using WitcherTextRpg.UI;

var ui = new ConsoleUI();
var combatService = new CombatService(ui);
var enemyFactory = new TerrainEnemyFactory();
var eventFactory = new ExplorationEventFactory(enemyFactory, combatService, ui);
var engine = new GameEngine(ui, combatService, enemyFactory, eventFactory);

engine.Start();
