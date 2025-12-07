using System;
using Game.View.Game;
using Game.View.Game.GameScreen;
using UnityEngine;

namespace Game.Configs
{
[Serializable]
public sealed class Game
{
    [field: SerializeField] public GameScreenView GameScreenView { get; private set; }
    [field: SerializeField] public BackgroundView BackgroundView { get; private set; }
    [field: SerializeField] public ItemView ItemView { get; private set; }
    [field: SerializeField] public LoseScreenView LoseScreenView { get; private set; }
    [field: SerializeField] public WinScreenView WinScreenView { get; private set; }
}
}