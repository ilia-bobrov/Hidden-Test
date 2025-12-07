using Game.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.View.Game
{
public sealed class LoseScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private TextMeshProUGUI _descText;
    
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

    public void SetCounts(int discoveredCount, int totalCount)
    {
        _descText.text = string.Format(_descText.text, discoveredCount, totalCount);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}