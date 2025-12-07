using VContainer;

namespace Game.Input
{
public sealed class MenuPlayerInput
{
    [Inject] private InputActions _inputActions;
    
    public bool IsPlay;
    public bool IsExit;
    
    public void Update()
    {
        IsExit |= _inputActions.UI.Cancel.WasPressedThisFrame();
    }
    
    public void Reset()
    {
        IsPlay = false;
        IsExit = false;
    }

    
}
}