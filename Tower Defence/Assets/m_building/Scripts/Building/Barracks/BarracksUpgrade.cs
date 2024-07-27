using UnityEngine;
using Zenject;

[RequireComponent(typeof(BuildingUpgradeSystem), typeof(BarracksSoldierController), typeof(GetSpecificProperties))]
public class BarracksUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject _barracksChoisePanel;

    [Inject] private PlayerStateMove _playerStateMove;
    [Inject] private UpgradeButton _upgradeButton;
    
    private BarracksProperties _barracksProperties;
    private BarracksSoldierController _barracks;
    private BuildingUpgradeSystem _buildingUpSystem;   
    
    private void Start()
    {
        _barracksProperties = GetComponent<GetSpecificProperties>().barracksProperties;
        _barracks = GetComponent<BarracksSoldierController>();
        _buildingUpSystem = GetComponent<BuildingUpgradeSystem>();   
             
        _barracksChoisePanel.SetActive(false);
    }

    public void CheckUpgrade(string name)
    {
        if (name == transform.name)
        {
            _barracks.SoldierCount = _barracksProperties.soldierCount[_buildingUpSystem.NowUp - 1];

            if (_buildingUpSystem.NowUp == 1)
            {
                _playerStateMove.FalseMove();
                _barracksChoisePanel.SetActive(true);
            }
            else
            {
                _barracks.RespawnSoldier();
            }                    
        }
    }

    private void OnEnable() 
    {
        _upgradeButton.onUpgrade += CheckUpgrade; 
    }

    private void OnDisable()
    {
        _upgradeButton.onUpgrade -= CheckUpgrade; 
    }
}