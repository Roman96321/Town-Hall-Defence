using UnityEngine;
using Zenject;

public class UpgradeWindowInstaller : MonoInstaller
{
    [SerializeField] private UpgradeWindow _upgradeWindow;

    public override void InstallBindings()
    {
        Container.Bind<UpgradeWindow>().FromInstance(_upgradeWindow).AsSingle().NonLazy();
    }
}