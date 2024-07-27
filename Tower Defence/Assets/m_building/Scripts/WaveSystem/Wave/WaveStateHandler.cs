using System;
using UnityEngine;

public class WaveStateHandler : MonoBehaviour
{
    public Action onWaveTrue;
    public Action onWaveFalse;

    public int nowWave { get; set; }

    public bool waveActive = false;

    public void WaweIsTrue()
    {
        waveActive = true;
        onWaveTrue?.Invoke();
    }

    public void WaveIsFalse()
    {
        nowWave++;
        waveActive = false;
        onWaveFalse?.Invoke();
    }
}
