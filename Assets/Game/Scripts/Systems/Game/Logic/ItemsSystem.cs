using System.Collections.Generic;
using Game.Configs;
using Game.Ev.Game;
using Game.Models.Logic;
using VContainer;

namespace Game.Systems.Game.Logic
{
public sealed class ItemsSystem
{
    [Inject] private Config _config;
    [Inject] private GameModel _gameModel;
    [Inject] private GameEvents _gameEvents;

    public void Start()
    {
        _gameModel.Items = new List<Item>();
        foreach (var item in _config.Items)
        {
            if (item.IsEnabled)
            {
                _gameModel.Items.Add(item);
            }
        }
        
        var itemsCount = _config.SimultaneousItemsCount > _gameModel.Items.Count ? _gameModel.Items.Count : _config.SimultaneousItemsCount;
        _gameModel.AvailableItems = new List<int>(itemsCount);
        for (int i = 0; i < itemsCount; i++)
        {
            _gameModel.AvailableItems.Add(i);
        }

        _gameModel.DiscoveredItemsCount = 0;
    }

    public void Update()
    {
        var ev = _gameEvents.ItemFound;
        if (ev.IsOn)
        {
            var indexOf = _gameModel.AvailableItems.IndexOf(ev.Index);
            if (indexOf >= 0)
            {
                var nextItemIndex = _gameModel.DiscoveredItemsCount + _config.SimultaneousItemsCount;
                if (_gameModel.Items.Count > nextItemIndex)
                {
                    _gameModel.AvailableItems[indexOf] = nextItemIndex;
                }
                else
                {
                    _gameModel.AvailableItems.RemoveAt(indexOf);
                }

                _gameModel.DiscoveredItemsCount++;

                SendDoneEvent(ev);
            }
        }
    }

    private void SendDoneEvent(ItemFoundEvent ev)
    {
        _gameEvents.ItemDone = new ItemDoneEvent
        {
            IsOn = true,
            Index = ev.Index,
        };
    }

    public void Stop()
    {
        _gameModel.Items = null;
        _gameModel.AvailableItems = null;
    }
}
}