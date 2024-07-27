using UnityEngine;
using Zenject;

public class GetBarracks : MonoBehaviour
{
    [Inject] private UpgradeButton _upgradeButton;

    private BarracksSoldierController _barracks;

    private void GetBaracksComponent(string name)
    {
        int intValue = (int)(char.GetNumericValue(name[default]));
        _barracks = transform.GetChild(intValue).GetComponent<BarracksSoldierController>();
    }

    public void SetBarracksSoldierType(string type)
    {       
        _barracks.SetSoldierType(type);
        _barracks = null;
    }

    private void OnEnable()
    {
        _upgradeButton.onUpgrade += GetBaracksComponent;
    }

    private void OnDisable()
    {
        _upgradeButton.onUpgrade -= GetBaracksComponent;
    }
}