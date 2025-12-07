using Game.Configs;

namespace Game.View.Game.GameScreen
{
public interface IItem
{
    public void SetData(Item itemData);
    public void SetActive(bool isActive);
    public bool IsActive();
}
}