using Game.Configs;
using Game.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace Game.View.Game
{
public class ItemView : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer _renderer;
    
    [Inject] private GamePlayerInput _input;
    private int _index;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    public void SetData(Item item, int index)
    {
        _renderer.sprite = item.ObjectSprite;
        transform.localPosition = item.Position;
        _index = index;
    }

    public float GetTransparency()
    {
        return _renderer.color.a;
    }
    
    public void SetTransparency(float transparency)
    {
        var color = _renderer.color;
        color.a = transparency;
        _renderer.color = color;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _input.ItemClicked = new ItemClickedAction
        {
            IsOn = true,
            Index = _index
        };
    }
}
}