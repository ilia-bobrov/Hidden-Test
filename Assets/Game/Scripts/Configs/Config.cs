using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
[CreateAssetMenu(fileName = "Config", menuName = "Game/Configs/Config")]
public sealed class Config : ScriptableObject
{
    [Header("Timer")]
    [field: SerializeField] public bool IsTimerEnabled { get; private set; }
    [field: SerializeField, Min(0)] public float TimerSecs { get; private set; }
    
    [field: Space, Header("Items")]
    [field: SerializeField] public bool IsItemsAsText { get; private set; }
    [field: SerializeField, Min(0)] public int SimultaneousItemsCount { get; private set; }
    [field: SerializeField, Min(0)] public float FadeTimeSecs { get; private set; }
    
    [Tooltip("Порядок в списке определяет порядок в игре"), Space, SerializeField]
    private List<Item> _items;
    public IReadOnlyList<Item> Items => _items;
    
    [field: Space]
    [field: SerializeField] public Background Background { get; private set; }
}

[Serializable]
public sealed class Background
{
    [field: SerializeField, Min(0)] public Vector2 MinVelocity { get; private set; }
    [field: SerializeField, Min(0)] public Vector2 MaxVelocity { get; private set; }
    [field: Space]
    [field: SerializeField] public Color MainColor { get; private set; }
    [field: SerializeField] public Color SpriteColor { get; private set; }
}

[Serializable]
public sealed class Item
{
    [field: SerializeField] public bool IsEnabled { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Vector2 Position { get; private set; }
    [field: SerializeField] public Sprite ObjectSprite { get; private set; }
    [field: SerializeField] public Sprite UiSprite { get; private set; }
}
}