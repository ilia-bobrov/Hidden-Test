using Game.Ev;
using Game.Input;
using Game.Models.Logic;
using Game.Systems.Menu;
using VContainer;
using VContainer.Unity;

namespace Game.States.Menu
{
public sealed class MenuState : IStartable
{
    [Inject] private Model _model;
    [Inject] private MenuModel _menuModel;
    [Inject] private Events _events;
    [Inject] private MenuPlayerInput _menuInput;
    
    [Inject] private InputSystem _inputSystem;
    
    [Inject] private MenuScreenViewSystem _menuScreenViewSystem;
    [Inject] private BackgroundViewSystem _backgroundViewSystem;

    public void Start()
    {
        _menuModel.State = EMenuState.Load;
    }
    
    public void Update()
    {
        _menuInput.Update();
        
        if (_menuModel.State is EMenuState.Load)
        {
            _menuScreenViewSystem.Start();
            _backgroundViewSystem.Start();
            _menuModel.State = EMenuState.Main;
        }
        else if (_menuModel.State is EMenuState.Main)
        {
            _inputSystem.Update();

            var ev = _events.ChangeState;
            if (ev.IsOn)
            {
                _menuScreenViewSystem.Stop();
                _backgroundViewSystem.Stop();
                
                _model.State = ev.State;
                _menuModel.State = EMenuState.Load;
            }
        }
        
        _menuInput.Reset();
    }
}
}