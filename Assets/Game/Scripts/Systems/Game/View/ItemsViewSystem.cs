using System;
using System.Collections.Generic;
using Game.Configs;
using Game.Ev.Game;
using Game.Models.Logic;
using Game.Models.View;
using Game.View.Game;
using UnityEngine;
using VContainer;

namespace Game.Systems.Game.View
{
public sealed class ItemsViewSystem
{
    [Inject] private Assets _assets;
    [Inject] private Config _config;
    [Inject] private GameModel _model;
    [Inject] private GameViewModel _viewModel;
    [Inject] private GameEvents _gameEvents;
    [Inject] private Func<MonoBehaviour, Transform, MonoBehaviour> _prefabFactory;
    
    public void Start()
    {
        _viewModel.Items = new List<ItemView>(_model.Items.Count);
        _viewModel.FadeItemIndexes = new HashSet<int>();

        for (var i = 0; i < _model.Items.Count; i++)
        {
            var item = _model.Items[i];
            var itemView = (ItemView)_prefabFactory(_assets.Game.ItemView, _viewModel.Background.transform);
            itemView.SetData(item, i);
            _viewModel.Items.Add(itemView);
        }
    }

    public void Update()
    {
        var ev = _gameEvents.ItemDone;
        if (ev.IsOn)
        {
            _viewModel.FadeItemIndexes.Add(ev.Index);
        }

        if (_viewModel.FadeItemIndexes.Count > 0)
        {
            var deltaFade = Time.deltaTime / _config.FadeTimeSecs;
            foreach (var index in _viewModel.FadeItemIndexes)
            {
                var itemView = _viewModel.Items[index];
                var transparency = itemView.GetTransparency();
                var newTransparency = transparency - deltaFade;
                if (newTransparency <= 0)
                {
                    itemView.SetActive(false);
                }
                else
                {
                    itemView.SetTransparency(newTransparency);
                }
            }
        }
    }
    
    public void Stop()
    {
        foreach (var itemView in _viewModel.Items)
        {
            itemView.Destroy();
        }

        _viewModel.Items = null;
    }
}
}