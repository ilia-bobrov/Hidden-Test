using UnityEngine;

namespace Game.View.Game
{
[RequireComponent(typeof(SpriteRenderer))]
public class BackgroundView : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    public void SetWidth(float width)
    {
        var rect = _renderer.sprite.rect;
        var unitsWidth = rect.width / _renderer.sprite.pixelsPerUnit;
        var mult = width / unitsWidth;
        transform.localScale *= mult;
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}