using System;
using Game.Configs;
using Game.Models.View;
using Game.View.Game;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.View
{
public sealed class BackgroundViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private GameViewModel _viewModel;
    [Inject] private Camera _camera;
    [Inject] private Func<MonoBehaviour, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.Background = (BackgroundView) _prefabFactory(_assets.Game.BackgroundView);
        var cameraSize = _camera.orthographicSize * 2;
        _viewModel.Background.SetWidth(cameraSize * _camera.aspect);
    }
    
    public void Stop()
    {
        _viewModel.Background.Destroy();
        _viewModel.Background = null;
    }
}
}