using Game.Input;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.View.Menu
{
public sealed class MenuScreenView : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    
    [Inject] private MenuPlayerInput _playerInput;

    private void Awake()
    {
        _playButton.onClick.AddListener(() => _playerInput.IsPlay = true);
        _exitButton.onClick.AddListener(() => _playerInput.IsExit = true);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}