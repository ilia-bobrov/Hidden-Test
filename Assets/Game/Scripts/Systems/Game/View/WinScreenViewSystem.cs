using System;
using Game.Configs;
using Game.Models.View;
using Game.View.Game;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.View
{
public sealed class WinScreenViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private GameViewModel _viewModel;
    [Inject] private Canvas _canvas;
    [Inject] private Func<MonoBehaviour, Transform, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.WinScreen = (WinScreenView) _prefabFactory(_assets.Game.WinScreenView, _canvas.transform);
    }

    public void Stop()
    {
        _viewModel.WinScreen.Destroy();
        _viewModel.WinScreen = null;
    }
}
}