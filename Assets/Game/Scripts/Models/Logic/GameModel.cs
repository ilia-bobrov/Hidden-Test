using System.Collections.Generic;
using Game.Configs;
using Game.States.Game;

namespace Game.Models.Logic
{
public sealed class GameModel
{
    public EGameState State;
    
    public List<Item> Items;
    public List<int> AvailableItems;
    public int DiscoveredItemsCount;

    public float Timer;
}
}