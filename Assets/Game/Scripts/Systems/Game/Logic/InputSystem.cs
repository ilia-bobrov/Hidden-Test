using Game.Ev;
using Game.Ev.Game;
using Game.Input;
using Game.States;
using VContainer;
using ChangeStateEv = Game.Ev.ChangeStateEv;

namespace Game.Systems.Game.Logic
{
public sealed class InputSystem
{
    [Inject] private GamePlayerInput _playerInput;
    [Inject] private GameEvents _gameEvents;
    [Inject] private Events _events;
    
    public void Update()
    {
        if (_playerInput.IsExit)
        {
            _events.ChangeState = new ChangeStateEv
            {
                IsOn = true,
                State = EGlobalState.Menu
            };
        }
        else if (_playerInput.IsReplay)
        {
            _events.ChangeState = new ChangeStateEv
            {
                IsOn = true,
                State = EGlobalState.Game
            };
        }
        else if (_playerInput.ItemClicked.IsOn)
        {
            _gameEvents.ItemFound = new ItemFoundEvent
            {
                IsOn = true,
                Index = _playerInput.ItemClicked.Index,
            };
        }
    }
}
}