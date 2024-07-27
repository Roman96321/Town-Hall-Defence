using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerRecovery : MonoBehaviour
{
    [Inject] private PlayerProperties _playerProperties; 
    [Inject] private WaveStateHandler _waveState;
    
    private PlayerHealth _playerHealth;
    private float _recoveryHealth;
    private float _timeToNextRecovery = 2;

    [HideInInspector] public float recoveryTimer;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();

        _recoveryHealth = _playerProperties.recoveryHealth;
    }

    private void StartRecovery()
    { 
        StartCoroutine(Timer()); 
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeToNextRecovery);

        recoveryTimer++;
        if (recoveryTimer >= _timeToNextRecovery)
            _playerHealth.TakeHealth(_recoveryHealth);

        if (_waveState.waveActive)
            StartCoroutine(Timer());
        else
            _playerHealth.TakeHealth(100);
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += StartRecovery;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= StartRecovery;
    }
}