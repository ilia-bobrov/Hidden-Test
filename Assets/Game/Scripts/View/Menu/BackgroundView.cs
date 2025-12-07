using Game.Utils;
using UnityEngine;

namespace Game.View.Menu
{
[RequireComponent(typeof(MeshRenderer))]
public class BackgroundView : MonoBehaviour
{
    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void SetSize(float width, float height)
    {
        transform.localScale = new Vector3(width, height, 1f);
    }

    public void SetData(Color mainColor, Color spriteColor,Vector2 velocity)
    {
        _renderer.material.SetColor(MovableTilingPropertyNames.MainColor, mainColor);
        _renderer.material.SetColor(MovableTilingPropertyNames.SpriteColor, spriteColor);
        _renderer.material.SetVector(MovableTilingPropertyNames.Velocity, velocity);
    }
    
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}