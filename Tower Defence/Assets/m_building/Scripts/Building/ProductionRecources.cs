using UnityEngine;
using Zenject;

[RequireComponent(typeof(BuildingUpgradeSystem), typeof(GetBuildingProperties))]
public class ProductionRecources : MonoBehaviour
{
    [Inject] private ResourceFeatures _resourceFeatures;
    [Inject] private WaveStateHandler _waveState; 

    private BuildingUpgradeSystem _buildingUpSystem;
    private BuildingProperties _buildingProperties;

    private void Start()
    {
        _buildingProperties = GetComponent<GetBuildingProperties>().buildingProperties;
        _buildingUpSystem = GetComponent<BuildingUpgradeSystem>();              
    }

    private void Production()
    {
        int nowUp = _buildingUpSystem.NowUp;

        if (nowUp == 0)
            return;

        nowUp -= 1;
        _resourceFeatures.AddResource(ResourceType.Gold, _buildingProperties.productionGold[nowUp]);
        _resourceFeatures.AddResource(ResourceType.Tree, _buildingProperties.productionTree[nowUp]);
        _resourceFeatures.AddResource(ResourceType.Meat, _buildingProperties.productionEat[nowUp]);
    }

    private void OnEnable()
    {
        _waveState.onWaveFalse += Production; 
    }

    private void OnDisable()
    {
        _waveState.onWaveFalse -= Production;
    }
}