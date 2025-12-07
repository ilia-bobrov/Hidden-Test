using System;
using System.Collections.Generic;
using Game.Configs;
using Game.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Object = UnityEngine.Object;

namespace Game.View.Game.GameScreen
{
public sealed class GameScreenView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private RectTransform _itemsContainer;
    [SerializeField] private ItemTextView _itemTextPrefab;
    [SerializeField] private ItemImageView _itemImagePrefab;
    
    [Inject] private GamePlayerInput _playerInput;
    private readonly List<IItem> _items = new();
    private int _itemActiveCount;

    private void Awake()
    {
        _exitButton.onClick.AddListener(() => _playerInput.IsExit = true);
    }

    private void OnDestroy()
    {
        _exitButton.onClick.RemoveAllListeners();
    }

    public void Initialize(bool isText, int itemsCount)
    {
        Object prefab = isText ? _itemTextPrefab : _itemImagePrefab;

        for (int i = 0; i < itemsCount; i++)
        {
            var itemView = (IItem) Instantiate(prefab, _itemsContainer);
            itemView.SetActive(false);
            _items.Add(itemView);
        }
        
        _itemActiveCount = 0;
        SetContainerActive(false);
    }
    
    public void SetData(int index, Item itemData)
    {
        var itemView = _items[index];
        itemView.SetData(itemData);
        if (!itemView.IsActive())
        {
            if (_itemActiveCount == 0)
            {
                SetContainerActive(true);
            }
            
            itemView.SetActive(true);
            _itemActiveCount++;
        }
    }
    
    public void SetEmpty(int index)
    {
        var itemView = _items[index];
        if (itemView.IsActive())
        {
            itemView.SetActive(false);
            _itemActiveCount--;
            if (_itemActiveCount == 0)
            {
                SetContainerActive(false);
            }
        }
    }

    private void SetContainerActive(bool isActive)
    {
        _itemsContainer.gameObject.SetActive(isActive);
    }
    
    public void SetTimerActive(bool isActive)
    {
        _timerText.gameObject.SetActive(isActive);
    }

    public void SetTime(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        _timerText.text = timeSpan.ToString(@"hh\:mm\:ss");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
}