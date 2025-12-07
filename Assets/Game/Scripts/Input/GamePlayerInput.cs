using VContainer;

namespace Game.Input
{
public sealed class GamePlayerInput
{
    [Inject] private InputActions _inputActions;
    
    public bool IsExit;
    public bool IsReplay;
    public ItemClickedAction ItemClicked;
    
    public void Update()
    {
        IsExit |= _inputActions.UI.Cancel.IsPressed();
    }
    
    public void Reset()
    {
        IsExit = false;
        IsReplay = false;
        ItemClicked.IsOn = false;
    }
}

public struct ItemClickedAction
{
    public bool IsOn;
    public int Index;
}
}