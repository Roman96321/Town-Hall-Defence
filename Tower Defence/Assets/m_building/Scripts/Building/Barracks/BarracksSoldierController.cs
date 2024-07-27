using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BuildingUpgradeSystem), typeof(GetSpecificProperties))]
public class BarracksSoldierController : MonoBehaviour
{
    [SerializeField] private Transform _spawnSoldierPoint;

    [Inject] private DiContainer _container;
    [Inject] private WaveStateHandler _waveState;

    private List<GameObject> _soldier = new List<GameObject>();
    private BarracksProperties _barracksProperties;
    private BuildingUpgradeSystem _buildingUpSystem; 
    private GameObject _soldierPrefab;
    private string _soldierType;
    private int _soldierCount; 
    private int spawnRange = 3;

    public string SoldierType {get => _soldierType; set => _soldierType = value;}
    public int SoldierCount {get => _soldierCount; set => _soldierCount = value;}

    private void Awake()
    {
        _barracksProperties = GetComponent<GetSpecificProperties>().barracksProperties;
        _buildingUpSystem = GetComponent<BuildingUpgradeSystem>();
    }

    public void SetSoldierType(string type)
    {
        SoldierType = type;

        if (type == "Knight")
            _soldierPrefab = _barracksProperties.knight;

        if (type == "Archer")
            _soldierPrefab = _barracksProperties.archer;
       
        SpawnSoldier(_soldierPrefab, SoldierCount);
    }

    private void SpawnSoldier(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(_spawnSoldierPoint.position.x - spawnRange, _spawnSoldierPoint.position.x + spawnRange);
            Vector3 randomPosition = new Vector3(randomX, _spawnSoldierPoint.position.y, _spawnSoldierPoint.position.z);

            _soldier.Add(_container.InstantiatePrefab(prefab, randomPosition, Quaternion.identity, null));
        }        
    }

    public void RespawnSoldier()
    {
        if (_buildingUpSystem.NowUp == default)
            return;

        int respawnSoldierCount = SoldierCount - _soldier.Count;

        for (int i = 0; i < _soldier.Count; i++) 
        {
            if (_soldier[i] == null)
                _soldier.RemoveAt(i);
        }

        SpawnSoldier(_soldierPrefab, respawnSoldierCount);

        if (_soldier.Count != SoldierCount)
            RespawnSoldier();
    }

    private void LoadSoldierType()
    {
        SetSoldierType(SoldierType);
    }

    private void OnEnable()
    {
        _buildingUpSystem.onUpgrade += LoadSoldierType;
        _waveState.onWaveFalse += RespawnSoldier;       
    }

    private void OnDisable()
    {
        _buildingUpSystem.onUpgrade -= LoadSoldierType;
        _waveState.onWaveFalse -= RespawnSoldier;      
    } 
}