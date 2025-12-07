using System;
using Game.Configs;
using Game.Models.Logic;
using Game.Models.View;
using Game.View.Game;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.View
{
public sealed class LoseScreenViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private GameModel _model;
    [Inject] private GameViewModel _viewModel;
    [Inject] private Canvas _canvas;
    [Inject] private Func<MonoBehaviour, Transform, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.LoseScreen = (LoseScreenView) _prefabFactory(_assets.Game.LoseScreenView, _canvas.transform);
        _viewModel.LoseScreen.SetCounts(_model.DiscoveredItemsCount, _model.Items.Count);
    }

    public void Stop()
    {
        _viewModel.LoseScreen.Destroy();
        _viewModel.LoseScreen = null;
    }
}
}