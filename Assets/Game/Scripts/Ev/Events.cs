using Game.States;

namespace Game.Ev
{
public sealed class Events
{
    public bool IsExit;
    public ChangeStateEv ChangeState;
    
    public void Reset()
    {
        IsExit = false;
        ChangeState.IsOn = false;
    }
}

public struct ChangeStateEv
{
    public bool IsOn;
    public EGlobalState State;
}
}