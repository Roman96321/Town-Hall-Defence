using UnityEngine;
using Zenject;

[RequireComponent(typeof(GetBuildingProperties), typeof(BuildingUpgradeSystem))]
public class BuildingHealth : MonoBehaviour
{
    [Inject] private WaveStateHandler _waveState;

    private BuildingUpgradeSystem _buildingUpSystem;
    private BuildingProperties _buildingProperties;     
    private float _maxHealth;
    private float _health;

    private void Awake()
    {
        _buildingUpSystem = GetComponent<BuildingUpgradeSystem>();
        _buildingProperties = GetComponent<GetBuildingProperties>().buildingProperties;
    }

    private void Start()
    {        
        SetHealth();
    }

    private void SetHealth()
    {
        int nowUp = _buildingUpSystem.NowUp;
        nowUp = nowUp == 0 ? 1 : nowUp;

        _maxHealth = _buildingProperties.health[nowUp-1];
        ResetHealth();
    }

    private void CheakDeadAndSetActive()
    {
        if (_health <= 0)
        {
            if (_buildingUpSystem.ImTownHall)
                GetComponent<GameOver>().GameIsAnd();

            transform.GetChild(default).gameObject.SetActive(false);
        }          
    }

    private void ResetHealth()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
            _health -= damage;
            
        CheakDeadAndSetActive();
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += ResetHealth;
        _buildingUpSystem.onUpgrade += SetHealth;
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= ResetHealth;
        _buildingUpSystem.onUpgrade -= SetHealth;
    }
}