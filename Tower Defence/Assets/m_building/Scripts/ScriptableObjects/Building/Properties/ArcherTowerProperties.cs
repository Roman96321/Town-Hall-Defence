using UnityEngine;

[CreateAssetMenu(menuName = "Properties/Building/StandartProperties/ArcherTowerProperties", fileName = "ArcherTowerProperties")]
public class ArcherTowerProperties : BuildingProperties
{
    public int[] damage;
    public int attackRange;
    public int attackSpeed;
    public GameObject arrowPrefab;
}
