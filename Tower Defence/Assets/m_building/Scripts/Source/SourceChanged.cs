using System.Collections;
using UnityEngine;
using Zenject;

public class SourceChanged : MonoBehaviour
{
    [SerializeField] private AudioSource _mainSource;
    [SerializeField] private AudioSource _waveSource;

    [Inject] private WaveStateHandler _waveState;

    private void Start()
    {
        MainSource();
    }

    private void MainSource()
    {
        StartCoroutine(StopSource(_waveSource));

        _mainSource.PlayDelayed(1);
        _mainSource.loop = true;
    }

    private void WaveSource()
    {
        StartCoroutine(StopSource(_mainSource));

        _waveSource.PlayDelayed(1);
        _waveSource.loop = true;
    }

    private IEnumerator StopSource(AudioSource source)
    {
        float startVolume = source.volume;

        while (source.volume > 0)
        {
            source.volume -= startVolume * Time.deltaTime / 1;
            yield return null;
        }

        source.loop = false;
        source.Stop();
        source.volume = startVolume;
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += WaveSource;
        _waveState.onWaveFalse += MainSource;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= WaveSource;
        _waveState.onWaveFalse += MainSource;
    }
}  