using System;
using Game.Configs;
using Game.Ev;
using Game.Ev.Game;
using Game.Input;
using Game.Models.Logic;
using Game.Models.View;
using Game.States.Game;
using Game.States.Menu;
using Game.Systems.Game.Logic;
using Game.Systems.Game.View;
using Game.Systems.Menu;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using BackgroundViewSystem = Game.Systems.Menu.BackgroundViewSystem;
using InputSystem = Game.Systems.Game.Logic.InputSystem;

namespace Game.Core
{
public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Config _config;
    [SerializeField] private Assets _assets;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_config);
        builder.RegisterInstance(_assets);
        builder.RegisterInstance(_camera);
        builder.RegisterInstance(_canvas);

        builder.Register<Game>(Lifetime.Singleton).AsImplementedInterfaces();
        
        builder.Register<Model>(Lifetime.Singleton);
        
        var inputActions = new InputActions();
        inputActions.Enable();
        builder.RegisterInstance(inputActions);
        
        builder.Register<Events>(Lifetime.Singleton);

        RegisterMenuState(builder);
        RegisterGameState(builder);
        
        builder.RegisterFactory(PrefabFactoryWithParent, Lifetime.Singleton);
        builder.RegisterFactory(PrefabFactory, Lifetime.Singleton);
    }

    private void RegisterMenuState(IContainerBuilder builder)
    {
        builder.Register<MenuState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        
        builder.Register<MenuModel>(Lifetime.Singleton);
        builder.Register<MenuViewModel>(Lifetime.Singleton);
        builder.Register<MenuPlayerInput>(Lifetime.Singleton);
        
        builder.Register<Systems.Menu.InputSystem>(Lifetime.Singleton);
        
        builder.Register<MenuScreenViewSystem>(Lifetime.Singleton);
        builder.Register<BackgroundViewSystem>(Lifetime.Singleton);
    }

    private void RegisterGameState(IContainerBuilder builder)
    {
        builder.Register<GameState>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        
        builder.Register<GameModel>(Lifetime.Singleton);
        builder.Register<GameViewModel>(Lifetime.Singleton);
        builder.Register<GamePlayerInput>(Lifetime.Singleton);
        builder.Register<GameEvents>(Lifetime.Singleton);
        
        builder.Register<InputSystem>(Lifetime.Singleton);
        builder.Register<ItemsSystem>(Lifetime.Singleton);
        builder.Register<TimerSystem>(Lifetime.Singleton);
        builder.Register<GameOverSystem>(Lifetime.Singleton);
        
        builder.Register<GameScreenViewSystem>(Lifetime.Singleton);
        builder.Register<Systems.Game.View.BackgroundViewSystem>(Lifetime.Singleton);
        builder.Register<ItemsViewSystem>(Lifetime.Singleton);
        builder.Register<WinScreenViewSystem>(Lifetime.Singleton);
        builder.Register<LoseScreenViewSystem>(Lifetime.Singleton);
    }

    private Func<MonoBehaviour, Transform, MonoBehaviour> PrefabFactoryWithParent(IObjectResolver container)
    {
        return (prefab, parent) => container.Instantiate(prefab, parent);
    }
    
    private Func<MonoBehaviour, MonoBehaviour> PrefabFactory(IObjectResolver container)
    {
        return container.Instantiate;
    }
}
}