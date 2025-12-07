using Game.Configs;
using TMPro;
using UnityEngine;

namespace Game.View.Game.GameScreen
{
public sealed class ItemTextView : MonoBehaviour, IItem
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetData(Item itemData)
    {
        _text.text = itemData.Name;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
}