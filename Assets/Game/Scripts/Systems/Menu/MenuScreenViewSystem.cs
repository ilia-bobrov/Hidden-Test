using System;
using Game.Configs;
using Game.Models.View;
using Game.View.Menu;
using UnityEngine;
using VContainer;

namespace Game.Systems.Menu
{
public sealed class MenuScreenViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private MenuViewModel _viewModel;
    [Inject] private Canvas _canvas;
    [Inject] private Func<MonoBehaviour, Transform, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.MenuScreen = (MenuScreenView) _prefabFactory(_assets.Menu.MenuScreenView, _canvas.transform);
    }
    
    public void Stop()
    {
        _viewModel.MenuScreen.Destroy();
        _viewModel.MenuScreen = null;
    }
}
}