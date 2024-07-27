using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider))]
public class ColliderManipulate : MonoBehaviour
{
    [Inject] private WaveStateHandler _waveState;
    [Inject] private UpgradeButton _upgradeButton;

    private BoxCollider _boxCollider;
    private Vector3 _reset;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();

        _reset = _boxCollider.size;
        _boxCollider.size = new Vector3(0.8f, 3f, 0.8f);

        _upgradeButton.onUpgrade += FirstUpgrade;
    }

    private void ColliderIsWaveTrue()
    {
        _boxCollider.enabled = false;
    }

    private void ColliderIsWaveFalse()
    {
        _boxCollider.enabled = true;
    }

    public void ReSize()
    {
        _boxCollider.size = _reset;
    }   

    public void FirstUpgrade(string name)
    {
        if (name == gameObject.name)
        {
            _upgradeButton.onUpgrade -= FirstUpgrade;
            ReSize();
        }
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += ColliderIsWaveFalse;
        _waveState.onWaveTrue += ColliderIsWaveTrue;     
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= ColliderIsWaveFalse;
        _waveState.onWaveTrue -= ColliderIsWaveTrue;       
    }
}