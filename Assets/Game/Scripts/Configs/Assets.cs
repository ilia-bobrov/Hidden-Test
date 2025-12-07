using UnityEngine;

namespace Game.Configs
{
[CreateAssetMenu(fileName = "Assets", menuName = "Game/Assets/Assets")]
public sealed class Assets : ScriptableObject
{
    [field: SerializeField] public Menu Menu { get; private set; }
    [field: SerializeField] public Game Game { get; private set; }
}
}