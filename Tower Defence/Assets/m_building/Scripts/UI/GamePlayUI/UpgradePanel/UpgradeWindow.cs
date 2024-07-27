using UnityEngine;

[RequireComponent(typeof(UpgradeWindowText))]
public class UpgradeWindow : MonoBehaviour
{
    private UpgradeWindowText _upgradeWindowtext;

    [HideInInspector] public BuildingUpgradeSystem building;

    private void Awake()
    {
        _upgradeWindowtext = GetComponent<UpgradeWindowText>();    
    }

    private void OnEnable()
    {
        if (building != null)
        {
            int nowUp = building.NowUp;

            _upgradeWindowtext.ShowUpgradeWindowText(building.GoldForUp[nowUp], 
                building.TreeForUp[nowUp], 
                building.EatForUp[nowUp],
                building.BuildingName);
        }
    }
}