using UnityEngine;
using Zenject;

public class PlayerPropertiesInstaller : MonoInstaller
{
    [SerializeField] private PlayerProperties _properties;

    public override void InstallBindings()
    {
        Container.Bind<PlayerProperties>().FromInstance(_properties).AsSingle().NonLazy();
    }
}
