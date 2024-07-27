using System.Collections;
using UnityEngine;
using Zenject;

public class DisableBuildingForGates : MonoBehaviour
{
    [SerializeField] private GameObject[] _building;
    [SerializeField] private GameObject[] _gates;

    [Inject] private WaveStateHandler _waveState;

    private void StartCheack()
    {
        StartCoroutine(GatesActive());
    }

    private IEnumerator GatesActive()
    {
        foreach (var gates in _gates)
        {
            if (gates.activeSelf == false)
            {
                BuildingSetTag(Tag.Building);
                yield break;
            }
        }

        BuildingSetTag(Tag.Untagged);

        yield return new WaitForSeconds(2);
        StartCoroutine(GatesActive());
    }

    private void BuildingSetTag(string tag)
    {
        for (int i = 0; i < _building.Length; i++)
        {
            _building[i].tag = tag;
        }
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += StartCheack;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= StartCheack;
    }
}