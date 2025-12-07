using Game.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Game.GameScreen
{
public sealed class ItemImageView : MonoBehaviour, IItem
{
    [SerializeField] private Image _image;

    public void SetData(Item itemData)
    {
        _image.sprite = itemData.UiSprite;
        _image.SetNativeSize();
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