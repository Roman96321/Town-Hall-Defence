using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class DontTouchButton : MonoBehaviour
{
    [Inject] private WaveStateHandler _waveState;

    private Button _button;

    private void Start()
    {      
        _button = GetComponent<Button>();
    }

    private void Touch()
    {       
        _button.enabled = !_button.enabled;
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += Touch;
        _waveState.onWaveFalse += Touch;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= Touch;
        _waveState.onWaveFalse -= Touch;
    }
}