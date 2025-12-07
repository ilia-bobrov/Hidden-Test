using Game.Ev;
using Game.Input;
using Game.States;
using VContainer;

namespace Game.Systems.Menu
{
public sealed class InputSystem
{
    [Inject] private MenuPlayerInput _playerInput;
    [Inject] private Events _events;
    
    public void Update()
    {
        if (_playerInput.IsExit)
        {
            _events.IsExit = true;
        }
        else if (_playerInput.IsPlay)
        {
            _events.ChangeState = new ChangeStateEv
            {
                IsOn = true,
                State = EGlobalState.Game
            };
        }
    }
}
}