using System;
using Game.View.Menu;
using UnityEngine;

namespace Game.Configs
{
[Serializable]
public sealed class Menu
{
    [field: SerializeField] public MenuScreenView MenuScreenView { get; private set; }
    [field: SerializeField] public BackgroundView BackgroundView { get; private set; }
}
}