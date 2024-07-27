using UnityEngine;
using Zenject;

public class WaveActiveInstaller : MonoInstaller
{
    [SerializeField] private WaveStateHandler _waveState;

    public override void InstallBindings()
    {
        Container.Bind<WaveStateHandler>().FromInstance(_waveState).AsSingle().NonLazy();
    }
}