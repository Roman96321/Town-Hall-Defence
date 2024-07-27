using UnityEngine;
using Zenject;

public class PlayerStateMoveInstaller : MonoInstaller
{
    [SerializeField] private PlayerStateMove _stateMove;

    public override void InstallBindings()
    {
        Container.Bind<PlayerStateMove>().FromInstance(_stateMove).AsSingle().NonLazy();
    }
}