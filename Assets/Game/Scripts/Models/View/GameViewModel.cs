using System.Collections.Generic;
using Game.View.Game;
using Game.View.Game.GameScreen;

namespace Game.Models.View
{
public sealed class GameViewModel
{
    public GameScreenView GameScreen;
    public WinScreenView WinScreen;
    public LoseScreenView LoseScreen;
    public BackgroundView Background;
    public List<ItemView> Items;
    public HashSet<int> FadeItemIndexes;
}
}