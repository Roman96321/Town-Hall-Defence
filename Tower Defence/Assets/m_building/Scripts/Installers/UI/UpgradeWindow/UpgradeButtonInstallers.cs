using UnityEngine;
using Zenject;

public class UpgradeButtonInstallers : MonoInstaller
{
    [SerializeField] private UpgradeButton _upgradeButton;

    public override void InstallBindings()
    {
        Container.Bind<UpgradeButton>().FromInstance(_upgradeButton).AsSingle().NonLazy();
    }
}