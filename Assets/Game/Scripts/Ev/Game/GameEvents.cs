using Game.States.Game;

namespace Game.Ev.Game
{
public sealed class GameEvents
{
    public ItemFoundEvent ItemFound;
    public ItemDoneEvent ItemDone;
    public bool IsTimerExpired;
    public ChangeStateEv ChangeState;
    
    public void Reset()
    {
        ItemFound.IsOn = false;
        ItemDone.IsOn = false;
        IsTimerExpired = false;
        ChangeState.IsOn = false;
    }
}

public struct ItemFoundEvent
{
    public bool IsOn;
    public int Index;
}

public struct ItemDoneEvent
{
    public bool IsOn;
    public int Index;
}

public struct ChangeStateEv
{
    public bool IsOn;
    public EGameState State;
}
}