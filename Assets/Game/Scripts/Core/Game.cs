using Game.Ev;
using Game.Models.Logic;
using Game.States;
using Game.States.Game;
using Game.States.Menu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Core
{
public sealed class Game : IStartable, ITickable
{
    [Inject] private Model _model;
    [Inject] private Events _events;
    [Inject] private MenuState _menuState;
    [Inject] private GameState _gameState;
    
    public void Start()
    {
        _model.State = EGlobalState.Menu;
    }

    public void Tick()
    {
        
        if (_model.State == EGlobalState.Menu)
        {
            _menuState.Update();
        }
        else if (_model.State == EGlobalState.Game)
        {
            _gameState.Update();
        }

        if (_events.IsExit)
        {
            ExitGame();
            return;
        }
        
        _events.Reset();
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
}