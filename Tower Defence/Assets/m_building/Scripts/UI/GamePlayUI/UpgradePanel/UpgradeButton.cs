using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ExitUpgradeWindow), typeof(UpgradeWindowText))]
public class UpgradeButton : MonoBehaviour
{   
    public Action<string> onUpgrade;

    [SerializeField] private GameObject _errorWindow;

    [Inject] private ResourceFeatures _resourceFeatures;
    [Inject] private UpgradeWindow _upgradeWindow;

    private ExitUpgradeWindow _exitUpgradeWindow;
    private UpgradeWindowText _upgradeWindowText;

    private void Start()
    {
        _exitUpgradeWindow = GetComponent<ExitUpgradeWindow>();
        _upgradeWindowText = GetComponent<UpgradeWindowText>();
    }

    public void UpgradeBuilding()
    {       
        if (_resourceFeatures.GetResource(ResourceType.Gold) >= _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Gold) && _resourceFeatures.GetResource(ResourceType.Tree) >= _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Tree) && _resourceFeatures.GetResource(ResourceType.Meat) >= _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Meat))
        {
            _resourceFeatures.SpendResource(ResourceType.Gold, _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Gold));
            _resourceFeatures.SpendResource(ResourceType.Tree, _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Tree));
            _resourceFeatures.SpendResource(ResourceType.Meat, _upgradeWindowText.GetUpgradeResourceValue(ResourceType.Meat));          
            _upgradeWindow.building.UpgradeIsTrue();
            
            onUpgrade.Invoke(_upgradeWindow.building.name);
        }
        else
        {       
            _errorWindow.SetActive(true);
        }

        _exitUpgradeWindow.Exit();
    }
}