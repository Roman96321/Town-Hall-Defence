using UnityEngine;
using Zenject;

public class PlayerHpInstaller : MonoInstaller
{
    [SerializeField] private PlayerHealth _playerHp;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromInstance(_playerHp).AsSingle().NonLazy();
    }
}