using Game.Configs;
using Game.Ev.Game;
using Game.Models.Logic;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.Logic
{
public sealed class TimerSystem
{
    [Inject] private Config _config;
    [Inject] private GameModel _gameModel;
    [Inject] private GameEvents _events;

    public void Start()
    {
        if (_config.IsTimerEnabled)
        {
            _gameModel.Timer = _config.TimerSecs;
        }
    }

    public void Update()
    {
        if (_config.IsTimerEnabled && _gameModel.Timer > 0)
        {
            _gameModel.Timer -= Time.deltaTime;
            if (_gameModel.Timer <= 0)
            {
                _gameModel.Timer = 0;
                
                _events.IsTimerExpired = true;
            }
        }
    }
}
}