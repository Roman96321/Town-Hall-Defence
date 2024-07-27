using UnityEngine;
using Zenject;

[RequireComponent(typeof(BuildingUpgradeSystem))]
public class ResetBuilding : MonoBehaviour
{
    [Inject] private WaveStateHandler _waveState;

    private BuildingUpgradeSystem _building;

    private void Start()
    {
        _building = GetComponent<BuildingUpgradeSystem>();
    }

    private void Reset()
    {
        if (_building.NowUp == default)
            return;

        if (transform.GetChild(default).gameObject.activeSelf == false)
            transform.GetChild(default).gameObject.SetActive(true);     
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += Reset;
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= Reset;
    }
}
