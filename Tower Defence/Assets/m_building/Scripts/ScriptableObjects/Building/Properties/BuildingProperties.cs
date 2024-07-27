using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Building/StandartProperties", fileName = "Properties")]
public class BuildingProperties : ScriptableObject
{
    [Header("UpgradeProperties")]
    public int[] health;

    [Header("UpgradeProducrion")]
    public int[] productionGold;
    public int[] productionTree;
    public int[] productionEat;
}