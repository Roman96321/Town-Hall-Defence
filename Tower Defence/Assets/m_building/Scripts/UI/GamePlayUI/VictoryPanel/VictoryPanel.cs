using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class VictoryPanel : MonoBehaviour
{
    [Inject] private PlayerStateMove _playerStateMove;
    [Inject] private WaveStateHandler _waveState;
    
    private GameObject _victoryPanel;
    private AudioSource _audioSource;

    private void Start()
    {
        _victoryPanel = transform.GetChild(default).gameObject;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Enable()
    {
        StartCoroutine(EnebleVictoryPanel());
    }

    private IEnumerator EnebleVictoryPanel()
    {
        yield return new WaitForSeconds(1);

        _victoryPanel.SetActive(true);
        _playerStateMove.FalseMove();
        _audioSource.Play();
    }

    public void Disable()
    {
        _victoryPanel.SetActive(false);
        _playerStateMove.TrueMove();
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += Enable;
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= Enable;
    }
}