using Game.Configs;
using Game.Ev.Game;
using Game.Models.Logic;
using Game.States.Game;
using VContainer;

namespace Game.Systems.Game.Logic
{
public sealed class GameOverSystem
{
    [Inject] private Config _config;
    [Inject] private GameModel _gameModel;
    [Inject] private GameEvents _events;

    public void Update()
    {
        if(_events.IsTimerExpired)
        {
            _events.ChangeState = new ChangeStateEv
            {
                IsOn = true,
                State = EGameState.LoseLoad
            };
            return;
        }

        var ev = _events.ItemDone;
        if (ev.IsOn)
        {
            if(_gameModel.AvailableItems.Count == 0)
            {
                _events.ChangeState = new ChangeStateEv
                {
                    IsOn = true,
                    State = EGameState.WinLoad
                };
            }
        }
    }
}
}