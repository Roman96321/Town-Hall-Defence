using UnityEngine;
using Zenject;

public class BuildingTakeDamageInstaller : MonoInstaller
{
    [SerializeField] private BuildingTakeDamage _buildingTakeDamage;

    public override void InstallBindings()
    {
        Container.Bind<BuildingTakeDamage>().FromInstance(_buildingTakeDamage).AsSingle().NonLazy();
    }
}