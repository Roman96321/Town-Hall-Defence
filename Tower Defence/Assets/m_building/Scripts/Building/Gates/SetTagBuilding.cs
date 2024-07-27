using UnityEngine;
using Zenject;

public class SetTagBuilding : MonoBehaviour
{
    [SerializeField] private GameObject[] _gates;

    [Inject] private WaveStateHandler _waveState;
   
    private void SetTag(string tag)
    {
        for (int i = 0; i < _gates.Length; i++)
            _gates[i].tag = tag;
    }

    private void CheackEnableBuilding()
    {
        foreach (var gates in _gates)
        {
            if (gates.gameObject.activeSelf == false)
            {
                gameObject.tag = Tag.Untagged;
                return;
            }
        }
        gameObject.tag = Tag.Building;
    }

    private void OnEnable()
    {
        SetTag(Tag.Building);
        _waveState.onWaveTrue += CheackEnableBuilding;
    }

    private void OnDisable()
    {
        SetTag(Tag.Untagged);
        _waveState.onWaveTrue -= CheackEnableBuilding;
    } 
}