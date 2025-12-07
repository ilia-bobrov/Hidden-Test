using System;
using Game.Configs;
using Game.Ev.Game;
using Game.Models.Logic;
using Game.Models.View;
using Game.View.Game.GameScreen;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.View
{
public sealed class GameScreenViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private Config _config;
    [Inject] private GameModel _model;
    [Inject] private GameViewModel _viewModel;
    [Inject] private GameEvents _gameEvents;
    [Inject] private Canvas _canvas;
    [Inject] private Func<MonoBehaviour, Transform, MonoBehaviour> _prefabFactory;
    private int _itemsCount;
    
    public void Start()
    {
        _viewModel.GameScreen = (GameScreenView) _prefabFactory(_assets.Game.GameScreenView, _canvas.transform);

        _itemsCount = _model.AvailableItems.Count;
        _viewModel.GameScreen.Initialize(_config.IsItemsAsText, _itemsCount);
        UpdateItems();
        
        _viewModel.GameScreen.SetTimerActive(_config.IsTimerEnabled);
        if (_config.IsTimerEnabled)
        {
            _viewModel.GameScreen.SetTime(_model.Timer);
        }
    }

    public void Update()
    {
        var ev = _gameEvents.ItemDone;
        if (ev.IsOn)
        {
            UpdateItems();
        }
        
        if (_config.IsTimerEnabled)
        {
            _viewModel.GameScreen.SetTime(_model.Timer);
        }
    }
    
    private void UpdateItems()
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            if (i < _model.AvailableItems.Count)
            {
                var index = _model.AvailableItems[i];
                _viewModel.GameScreen.SetData(i, _model.Items[index]);
            }
            else
            {
                _viewModel.GameScreen.SetEmpty(i);
            }
        }
    }
    
    public void Stop()
    {
        _viewModel.GameScreen.Destroy();
        _viewModel.GameScreen = null;
    }
}
}