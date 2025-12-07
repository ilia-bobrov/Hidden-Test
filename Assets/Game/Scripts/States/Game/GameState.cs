using Game.Ev;
using Game.Ev.Game;
using Game.Input;
using Game.Models.Logic;
using Game.Systems.Game.Logic;
using Game.Systems.Game.View;
using VContainer;
using VContainer.Unity;

namespace Game.States.Game
{
public sealed class GameState : IStartable
{
    [Inject] private Model _model;
    [Inject] private GameModel _gameModel;
    [Inject] private Events _events;
    [Inject] private GameEvents _gameEvents;
    [Inject] private GamePlayerInput _gameInput;
    
    [Inject] private InputSystem _inputSystem;
    [Inject] private ItemsSystem _itemsSystem;
    [Inject] private TimerSystem _timerSystem;
    [Inject] private GameOverSystem _gameOverSystem;
    
    [Inject] private GameScreenViewSystem _gameScreenViewSystem;
    [Inject] private BackgroundViewSystem _backgroundViewSystem;
    [Inject] private ItemsViewSystem _itemsViewSystem;
    [Inject] private WinScreenViewSystem _winScreenViewSystem;
    [Inject] private LoseScreenViewSystem _loseScreenViewSystem;

    public void Start()
    {
        _gameModel.State = EGameState.Load;
    }
    
    public void Update()
    {
        _gameInput.Update();
        
        if (_gameModel.State is EGameState.Load)
        {
            _itemsSystem.Start();
            _timerSystem.Start();
            
            _gameScreenViewSystem.Start();
            _backgroundViewSystem.Start();
            _itemsViewSystem.Start();
            
            _gameModel.State = EGameState.Main;
        }
        else if (_gameModel.State is EGameState.Main)
        {
            _inputSystem.Update();
            _itemsSystem.Update();
            _timerSystem.Update();
            _gameOverSystem.Update();
            
            _gameScreenViewSystem.Update();
            _itemsViewSystem.Update();

            if (CheckGlobalStateChange())
            {
                StopCoreSystems();
            }
            else
            {
                var ev = _gameEvents.ChangeState;
                if (ev.IsOn)
                {
                    _gameModel.State = ev.State;
                }
            }
        }
        else if (_gameModel.State is EGameState.WinLoad)
        {
            _winScreenViewSystem.Start();
            _gameModel.State = EGameState.Win;
        }
        else if (_gameModel.State is EGameState.Win)
        {
            _inputSystem.Update();

            if (CheckGlobalStateChange())
            {
                StopCoreSystems();
                _winScreenViewSystem.Stop();
            }
        }
        else if (_gameModel.State is EGameState.LoseLoad)
        {
            _loseScreenViewSystem.Start();
            _gameModel.State = EGameState.Lose;
        }
        else if (_gameModel.State is EGameState.Lose)
        {
            _inputSystem.Update();
            
            if (CheckGlobalStateChange())
            {
                StopCoreSystems();
                _loseScreenViewSystem.Stop();
            }
        }
        
        _gameInput.Reset();
        _gameEvents.Reset();
    }

    private bool CheckGlobalStateChange()
    {
        var ev = _events.ChangeState;
        if (ev.IsOn)
        {
            _model.State = ev.State;
            _gameModel.State = EGameState.Load;

            return true;
        }

        return false;
    }

    private void StopCoreSystems()
    {
        _itemsSystem.Stop();
                
        _gameScreenViewSystem.Stop();
        _backgroundViewSystem.Stop();
        _itemsViewSystem.Stop();
    }
}
}