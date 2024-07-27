using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BuildingUpgradeSystem), typeof(SearchObject), typeof(GetSpecificProperties))]
public class ArcherTower : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointArrow;

    [Inject] private WaveStateHandler _waveState;

    private BuildingUpgradeSystem _buildingUpgradeSystem;
    private ArcherTowerProperties _properties;
    private GameObject _firstUpgrade;
    private SearchObject _searchObject; 

    private void Awake()
    {
        _properties = GetComponent<GetSpecificProperties>().archerTowerProperties;
        _buildingUpgradeSystem = GetComponent<BuildingUpgradeSystem>();
        _searchObject = GetComponent<SearchObject>();

        _firstUpgrade = transform.GetChild(default).gameObject;
    }

    private void StartAttack()
    {
        if (_buildingUpgradeSystem.NowUp > 0)
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(_properties.attackSpeed);    

        if (_firstUpgrade.activeSelf == true)
        {
            GameObject arrow = Instantiate(_properties.arrowPrefab, _spawnPointArrow.position, Quaternion.identity);

            SoldierArrow arrowScript = arrow.GetComponent<SoldierArrow>();
            arrowScript.Target = _searchObject.GetObject(_properties.attackRange, Tag.Enemy);
            arrowScript.Damage = _properties.damage[_buildingUpgradeSystem.NowUp - 1];
        }

        if (_waveState.waveActive && _firstUpgrade.activeSelf)
            StartCoroutine(Attack());    
    }

    private void OnEnable()
    {
        _waveState.onWaveTrue += StartAttack;
    }

    private void OnDisable()
    {
        _waveState.onWaveTrue -= StartAttack;
    }
}