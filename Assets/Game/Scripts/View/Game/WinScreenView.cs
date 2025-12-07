using Game.Input;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.View.Game
{
public sealed class WinScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _replayButton;
    
    [Inject] private GamePlayerInput _playerInput;

    private void Awake()
    {
        _exitButton.onClick.AddListener(() => _playerInput.IsExit = true);
        _replayButton.onClick.AddListener(() => _playerInput.IsReplay = true);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveAllListeners();
        _replayButton.onClick.RemoveAllListeners();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}