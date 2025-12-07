using System;
using Game.Configs;
using Game.Models.View;
using Game.View.Menu;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Game.Systems.Menu
{
public class BackgroundViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private Config _config;
    [Inject] private MenuViewModel _viewModel;
    [Inject] private Camera _camera;
    [Inject] private Func<MonoBehaviour, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.Background = (BackgroundView) _prefabFactory(_assets.Menu.BackgroundView);
        var cameraSize = _camera.orthographicSize * 2;
        _viewModel.Background.SetSize(cameraSize * _camera.aspect + 1f, cameraSize + 1f);
        _viewModel.Background.SetData(_config.Background.MainColor, _config.Background.SpriteColor, GetVelocity());
    }

    private Vector2 GetVelocity()
    {
        var x = Random.Range(_config.Background.MinVelocity.x, _config.Background.MaxVelocity.x);
        x *= Random.value > 0.5f ? -1 : 1;
        var y = Random.Range(_config.Background.MinVelocity.y, _config.Background.MaxVelocity.y);
        y *= Random.value > 0.5f ? -1 : 1;
        return new Vector2(x, y);
    }

    public void Stop()
    {
        _viewModel.Background.Destroy();
        _viewModel.Background = null;
    }
}
}